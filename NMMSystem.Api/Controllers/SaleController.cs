using Microsoft.AspNetCore.Mvc;
using NMMSystem.Aplication.Service;
using NMMSystem.Aplication.Service.ProductServ;
using NNMSystem.Infrastructure.Dto.AddProduct;

namespace NMMSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController:ControllerBase
    {
        private readonly IProductService _productService;

        public SaleController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("AddProduct")]
        public async Task<ActionResult<ServiceResponce<string>>>AddProduct(AddProductDto request)
        {
            return Ok(await _productService.AddProducts(request));
        }
    }
}
