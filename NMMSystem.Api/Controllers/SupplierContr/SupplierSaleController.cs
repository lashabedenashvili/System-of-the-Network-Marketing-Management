using Microsoft.AspNetCore.Mvc;
using NMMSystem.Aplication.Service;
using NMMSystem.Aplication.Service.ProductServ;
using NMMSystem.Aplication.Service.SupplierRecomendatorsServ;
using NNMSystem.Infrastructure.Dto.AddProduct;
using NNMSystem.Infrastructure.Dto.SupplierSale;

namespace NMMSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierSaleController:ControllerBase
    {
        private readonly ISupplierSaleService _productService;
        private readonly ISupplierRecomendatorsService _supplierRecomendatorsService;

        public SupplierSaleController(ISupplierSaleService productService,ISupplierRecomendatorsService supplierRecomendatorsService)
        {
            _productService = productService;
            _supplierRecomendatorsService = supplierRecomendatorsService;
        }
        [HttpPost("AddProduct")]
        public async Task<ActionResult<ServiceResponce<string>>>AddProduct(AddProductDto request)
        {
            return Ok(await _productService.AddProducts(request));
        }
        [HttpPost("AddSupplierSale")]
        public async Task<ActionResult<ServiceResponce<string>>> AddSupplierSale(SupplierSaleDto request)
        {
            return Ok(await _productService.AddSupplierSale(request));
        }

        [HttpGet("GetProductIdByUserId")]
        public async Task<ActionResult<ServiceResponce<List<GetSupplierSalebysupplierDto>>>> GetProductIdByUserId(int supplierId)
        {
            return Ok(await _productService.GetSypplierSaleBySupplier(supplierId));
        }

        [HttpPost("FilterSale")]
        public async Task<ActionResult<ServiceResponce<List<GetSupplierSalebysupplierDto>>>> FilterSale(FilterDto filter)
        {
            return Ok(await _productService.FilterSale(filter));
        }
        [HttpGet("HierarchyControl")]
        public async Task<ActionResult<ServiceResponce<List<int>>>> HierarchyControl(int RecomenderSupplierId, int level)
        {
            return Ok(await _supplierRecomendatorsService.HierarchyControl(RecomenderSupplierId,level));
        }
       
      
        [HttpPost("GetSupplierIdBySaleDate")]
        public async Task<ActionResult<ServiceResponce<string>>> GetSupplierIdBySaleDate(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            return Ok(await _productService.GetSupplierIdBySaleDate(dateTimeFrom, dateTimeTo));
        }
        [HttpPost("SypplierBonusSystemFiler")]
        public async Task<ActionResult<ServiceResponce<List<GetSypplierBonusInformationDto>>>> SypplierBonusSystemFiler(SypplierBonusSystemFilterDto request)
        {
            return Ok(await _productService.SypplierBonusSystemFiler(request));
        }
    }
}
