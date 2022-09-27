using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NMMSystem.Aplication.Service.ProductServ;
using NMMSystem.Aplication.Service.SupplierRecomendatorsServ;
using NMMSystem.Data.Domein;
using NMMSystem.Data.Domein.Data;
using NNMSystem.Infrastructure.Dto.AddProduct;
using NNMSystem.Infrastructure.Dto.SupplierSale;

namespace NMMSystem.Aplication.Service.SaleServ
{
    public class SupplierSaleService : ISupplierSaleService
    {
        private readonly IContext _contex;
        private readonly IMapper _mapper;
        private readonly ISupplierRecomendatorsService _recomendatorsService;

        public SupplierSaleService(IContext contex,
        IMapper mapper, ISupplierRecomendatorsService recomendatorsService)
        {
            _contex = contex;
            _mapper = mapper;
            _recomendatorsService = recomendatorsService;
        }

        public async Task<ServiceResponce<string>> AddProducts(AddProductDto request)
        {
            var response = new ServiceResponce<string>();
            var product = _mapper.Map<Product>(request);
            _contex.Product.Add(product);
            await _contex.SaveChangesAsync();
            response.Success = true;
            return response;

        }

        public async Task<ServiceResponce<string>> AddSupplierSale(SupplierSaleDto request)
        {
            var response = new ServiceResponce<string>();
            var supplierSale = _mapper.Map<SupplierSale>(request);
            _contex.SupplierSale.Add(supplierSale);
            await _contex.SaveChangesAsync();
            response.Success = true;
            return response;

        }

        public async Task<ServiceResponce<List<GetSupplierSalebysupplierDto>>> GetSypplierSaleBySupplier(int supplierId)
        {
            var response = new ServiceResponce<List<GetSupplierSalebysupplierDto>>();
            var supplierExist = await SupplierExist(supplierId);
            if (!supplierExist.Success)
            {
                response.Success = false;
                response.Message = "Supplier doesnot exist";
                return response;
            }
            else
            {
                var supplieSale = await _contex.SupplierSale
                    .Where(x => x.SupplierId == supplierId)
                    .Include(x => x.Product)
                    .ToListAsync();


                response.Data = _mapper.Map<List<GetSupplierSalebysupplierDto>>(supplieSale);
            }
            return response;
        }

        private async Task<ServiceResponce<bool>> SupplierExist(int supplierId)
        {
            var responce = new ServiceResponce<bool>();
            responce.Success = await _contex.SupplierSale
                              .AnyAsync(x => x.SupplierId == supplierId);



            return responce;
        }

        public async Task<ServiceResponce<List<GetSupplierSalebysupplierDto>>> FilterSale(FilterDto filter)
        {
            var response = new ServiceResponce<List<GetSupplierSalebysupplierDto>>();

            var data = _contex.SupplierSale
                    .Include(x => x.Product).AsQueryable();

            if (filter.from.HasValue)
                data = data.Where(e => e.SaleTime > filter.from);
            if (filter.to.HasValue)
                data = data.Where(e => e.SaleTime < filter.to);
            if (filter.supplierId.HasValue)
                data = data.Where(e => e.SupplierId == filter.supplierId);
            if (filter.productid.HasValue)
                data = data.Where(e => e.ProductId == filter.productid);

            var returndata = await data.ToListAsync();

            response.Data = _mapper.Map<List<GetSupplierSalebysupplierDto>>(returndata);

            return response;

        }
        //private async Task<ServiceResponce<bool>> CheckBonusDate(DateTime dateTimeFrom, DateTime dateTimeTo, int supplierId)
        //{
        //    var responce = new ServiceResponce<bool>();
        //    var bonusTime = await _contex.SupplierBonusSpecificTime.Where(x => x.DateTimeFrom == dateTimeFrom && x.DateTimeTo == dateTimeTo && x.SupplierId == supplierId)
        //        .Select(x => x.TimePeriodBool).FirstOrDefaultAsync();

        //    if (bonusTime)
        //    {
        //        responce.Success = false;
        //        responce.Message = "In this date Supplier bonus is alredy count";
        //        return responce;
        //    }
        //    responce.Success = true;
        //    return responce;
        //}

        public async Task<ServiceResponce<string>> GetSupplierIdBySaleDate(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            List<SupplierBonusSpecificTime> supplierBonusTime = new();
            var responce = new ServiceResponce<string>();
            var suppliersId =await  _contex.SupplierSale
                .Where(x => x.SaleTime >= dateTimeFrom && x.SaleTime <= dateTimeTo && x.Counted==false)             
                .ToListAsync();

                

            
         
            foreach (var item in suppliersId.Select(e => e.SupplierId).Distinct())
            {
                

                var supplierCounted = _contex.SupplierSale
               .Where(x => x.SupplierId == item)
               .Select(X => X.Counted);

                var supplierBonus = await SupplierBonusSystem(item);
                    var supplier = await SupplierSurnameById(item);
                    var recordBonusDb = new SupplierBonusSpecificTime
                    {
                        Name = supplier.Data.Name,
                        Surname = supplier.Data.SurName,
                        SupplierId = item,
                        Bonus = supplierBonus.Data,
                        DateTimeFrom = dateTimeFrom,
                        DateTimeTo = dateTimeTo,

                    };
                supplierBonusTime.Add(recordBonusDb);
            }

            suppliersId.ForEach(x => x.Counted = true);

            _contex.SupplierBonusSpecificTime.AddRange(supplierBonusTime);
            _contex.SupplierSale.UpdateRange(suppliersId);
            await _contex.SaveChangesAsync();


            



            return responce;
        }
        private async Task<ServiceResponce<decimal>> SupplierBonusSystem(int supplierId)
        {

            var response = new ServiceResponce<decimal>();

            var supplierSale = await _contex.SupplierSale.Where(x => x.SupplierId == supplierId).SumAsync(x => x.TotalPrice);

            int hierarchyFirstLevel = 1;
            int sUpplierId = (int)supplierId;

            var firsLevel = await _recomendatorsService.HierarchyControl(sUpplierId, hierarchyFirstLevel);
            decimal firsLevelSum = 0;
            foreach (var item in firsLevel.Data)
            {
                var supplierSum = await _contex.SupplierSale
                     .Where(x => x.SupplierId == item)
                     .SumAsync(x => x.TotalPrice);
                firsLevelSum += supplierSum;
            }

            int hierarchySecondLevel = 2;

            var secondLevel = await _recomendatorsService.HierarchyControl(sUpplierId, hierarchySecondLevel);
            secondLevel.Data = secondLevel.Data.Except(firsLevel.Data).ToList();
            decimal SecondLevelSum = 0;
            foreach (var item in secondLevel.Data)
            {
                var supplierSum = await _contex.SupplierSale
                     .Where(x => x.SupplierId == item)
                     .SumAsync(x => x.TotalPrice);
                SecondLevelSum += supplierSum;
            }
            if (firsLevelSum == 0 && SecondLevelSum == 0)
            {
                response.Data = (supplierSale * (decimal)0.1);
                return response;
            }
            else if (firsLevelSum == 0)
            {
                response.Data = (supplierSale * (decimal)0.1) + (SecondLevelSum * (decimal)0.01);
                return response;
            }
            else
            {
                response.Data = (supplierSale * (decimal)0.1) + (SecondLevelSum * (decimal)0.01) + (firsLevelSum * (decimal)0.05);
            }



            return response;
        }
        public async Task<ServiceResponce<List<GetSypplierBonusInformationDto>>> SypplierBonusSystemFiler(SypplierBonusSystemFilterDto request)
        {
            var responce = new ServiceResponce<List<GetSypplierBonusInformationDto>>();

            var data = _contex.SupplierBonusSpecificTime.Include(e => e.Supplier).AsQueryable();


            if (request.Name != null)
            {
                data = data.Where(x => x.Supplier.Name == request.Name);
            }
            if (request.Surname != null)
            {
                data = data.Where(x => x.Supplier.SurName == request.Surname);
            }
            if (request.BonusMin.HasValue)
            {
                data = data.Where(x => x.Bonus >= request.BonusMin);
            }
            if (request.BonusMax.HasValue)
            {
                data = data.Where(x => x.Bonus <= request.BonusMax);
            }

            var finallyData = await data.ToListAsync();

            //List<GetSypplierBonusInformationDto> ss = new List<GetSypplierBonusInformationDto>();
            //foreach (var item in finallyData)
            //{
            //    var supplierName = await GetSupplierNameById(item.SupplierId);
            //    ss.Add(new GetSypplierBonusInformationDto
            //    {
            //        Name = supplierName.Data,
            //        Surname = item.Surname,
            //        SupplierId = item.SupplierId,
            //        Bonus = item.Bonus,
            //    });
            //};

            responce.Data = _mapper.Map<List<GetSypplierBonusInformationDto>>(finallyData);



            return responce;

        }

        private async Task<ServiceResponce<string>> GetSupplierNameById(int supplierId)
        {
            var responce = new ServiceResponce<string>();
            responce.Data = await _contex.Supplier
                .Where(x => x.Id == supplierId)
                .Select(x => x.Name)
                .FirstOrDefaultAsync();


            return responce;
        }
        private async Task<ServiceResponce<Supplier>> SupplierSurnameById(int supplierId)
        {
            var responce = new ServiceResponce<Supplier>();
            responce.Data = await _contex.Supplier.Where(x => x.Id == supplierId).FirstOrDefaultAsync();

            return responce;
        }




    }
}
