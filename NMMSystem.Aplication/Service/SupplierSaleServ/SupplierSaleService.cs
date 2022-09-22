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
    public class SupplierSaleService:ISupplierSaleService
    {
        private readonly IContext _contex;
        private readonly IMapper _mapper;
        private readonly ISupplierRecomendatorsService _recomendatorsService;

        public SupplierSaleService(IContext contex,
        IMapper mapper,ISupplierRecomendatorsService recomendatorsService)
        {
            _contex= contex;
            _mapper= mapper;
            _recomendatorsService = recomendatorsService;
        }

        public async Task<ServiceResponce<string>> AddProducts(AddProductDto request)
        {
            var response=new ServiceResponce<string>();
            var product=_mapper.Map<Product>(request);
            _contex.Product.Add(product);
            await _contex.SaveChangesAsync();
            response.Success = true;
            return response;
         
        }

        public async Task<ServiceResponce<string>> AddSupplierSale(SupplierSaleDto request)
        {
            var response = new ServiceResponce<string>();
            var supplierSale=_mapper.Map<SupplierSale>(request);
            _contex.SupplierSale.Add(supplierSale);
            await _contex.SaveChangesAsync();
            response.Success = true;
            return response;

        }

        public async Task<ServiceResponce<List<GetSupplierSalebysupplierDto>>> GetSypplierSaleBySupplier(int supplierId)
        {
           var response=new ServiceResponce< List<GetSupplierSalebysupplierDto>>();
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
         

               response.Data= _mapper.Map<List<GetSupplierSalebysupplierDto>>(supplieSale);
            }
            return response;
        }

        private async Task<ServiceResponce<bool>>SupplierExist(int supplierId)
        {
            var responce=new ServiceResponce<bool>();
            responce.Success = await _contex.SupplierSale
                              .AnyAsync(x=>x.SupplierId== supplierId);
             


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
            if(filter.supplierId.HasValue)
                data = data.Where(e => e.SupplierId == filter.supplierId);
            if (filter.productid.HasValue)
                data = data.Where(e => e.ProductId == filter.productid);

            var returndata = await data.ToListAsync();

            response.Data = _mapper.Map<List<GetSupplierSalebysupplierDto>>(returndata);

            return response;

        }

        public async Task<List<int>>GetSupplierIdBySaleDate(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            var suppliersId = _contex.SupplierSale
                .Where(x => x.SaleTime == dateTimeFrom && x.SaleTime == dateTimeTo)
                .Select(x=>x.SupplierId)
                .ToListAsync();

            foreach (var item in suppliersId.Result)
            {
               var supplierBonus= await SupplierBonusSystem(item);

            }
            
        }                   
        public async Task<ServiceResponce<decimal>> SupplierBonusSystem(int supplierId)
        {
            
            var response = new ServiceResponce<decimal>();

            //var data = _contex.SupplierSale
            //        .Include(x => x.Product).AsQueryable();
            //if (supplierId.HasValue)
            //{
            //    data = data.Where(e => e.SupplierId== supplierId);
            //}
            //if (dateTimeFrom.HasValue)
            //{
            //    data = data.Where(e => e.SaleTime == dateTimeFrom);
            //}
            //if (dateTimeTo.HasValue)
            //{
            //    data = data.Where(e => e.SaleTime == dateTimeTo);
            //}
            var supplierSale= await _contex.SupplierSale.Where(x=>x.SupplierId== supplierId).SumAsync(x=>x.TotalPrice);
             
            int hierarchyFirstLevel = 1;
            int sUpplierId =(int) supplierId;       

            var firsLevel=await _recomendatorsService.HierarchyControl(sUpplierId, hierarchyFirstLevel);
            decimal firsLevelSum = 0;
            foreach (var item in firsLevel.Data)
            {
                var supplierSum = await _contex.SupplierSale
                     .Where(x => x.SupplierId == item)
                     .SumAsync(x => x.TotalPrice);
                firsLevelSum +=supplierSum;
            }

            int hierarchySecondLevel = 2;

            var secondLevel = await _recomendatorsService.HierarchyControl(sUpplierId, hierarchySecondLevel);
            secondLevel.Data =  secondLevel.Data.Except(firsLevel.Data).ToList();
            decimal SecondLevelSum = 0;
            foreach (var item in secondLevel.Data)
            {
                var supplierSum = await _contex.SupplierSale
                     .Where(x => x.SupplierId == item)
                     .SumAsync(x => x.TotalPrice);
                SecondLevelSum += supplierSum;
            }
            if(firsLevelSum==0 && SecondLevelSum == 0)
            {
                response.Data = (supplierSale * (decimal)0.1);
                return response;
            }
            else if(firsLevelSum == 0)
            {
                response.Data = (supplierSale * (decimal)0.1)+(SecondLevelSum * (decimal)0.01);
                return response;
            }
            else
            {
                response.Data = (supplierSale * (decimal)0.1) + (SecondLevelSum * (decimal)0.01) + (firsLevelSum * (decimal)0.05);
            }

            

            

            return response;
        }
        private async Task<ServiceResponce<decimal>>SupplierTotalSale(int supplierId)
        {
            var response= new ServiceResponce<decimal>();
            response.Data = await _contex.SupplierSale
                .Where(x => x.SupplierId == supplierId)
                .SumAsync(x => x.TotalPrice);

            return response;
        }

        public Task<ServiceResponce<decimal>> SupplierBonusSystem(SupplierBonusSystemDto request)
        {
            throw new NotImplementedException();
        }
    }
}
