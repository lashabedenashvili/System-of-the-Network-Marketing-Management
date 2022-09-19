using Microsoft.AspNetCore.Mvc;
using NMMSystem.Aplication.Service;
using NMMSystem.Aplication.Service.ProductServ;
using NNMSystem.Infrastructure.Dto.AddProduct;
using NNMSystem.Infrastructure.Dto.SupplierSale;

namespace NMMSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierSaleController:ControllerBase
    {
        private readonly ISupplierSaleService _productService;

        public SupplierSaleController(ISupplierSaleService productService)
        {
            _productService = productService;
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
            return Ok(await _productService.FilterSalle(filter));
        }
    }
}
