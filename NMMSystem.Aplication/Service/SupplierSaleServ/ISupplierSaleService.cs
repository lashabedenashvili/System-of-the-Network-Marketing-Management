using NNMSystem.Infrastructure.Dto.AddProduct;
using NNMSystem.Infrastructure.Dto.SupplierSale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Aplication.Service.ProductServ
{
    public interface ISupplierSaleService
    {
         Task<ServiceResponce<string>> AddProducts(AddProductDto request);
        Task<ServiceResponce<string>> AddSupplierSale(SupplierSaleDto request);
        Task<ServiceResponce<List<GetSupplierSalebysupplierDto>>> GetSypplierSaleBySupplier(int supplierId);
        Task<ServiceResponce<List<GetSupplierSalebysupplierDto>>> FilterSale(FilterDto filter);      
        Task<List<int>> GetSupplierIdBySaleDate(DateTime dateTimeFrom, DateTime dateTimeTo);
        Task<ServiceResponce<List<GetSypplierBonusInformationDto>>> SypplierBonusSystemFiler(SypplierBonusSystemFilterDto request);
    }
}
