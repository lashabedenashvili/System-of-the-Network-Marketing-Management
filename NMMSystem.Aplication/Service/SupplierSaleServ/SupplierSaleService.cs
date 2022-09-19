using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NMMSystem.Aplication.Service.ProductServ;
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

        public SupplierSaleService(IContext contex,
        IMapper mapper)
        {
            _contex= contex;
            _mapper= mapper;

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

        public async Task<ServiceResponce<List<GetSupplierSalebysupplierDto>>> FilterSalle(FilterDto filter)
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

    }
}
