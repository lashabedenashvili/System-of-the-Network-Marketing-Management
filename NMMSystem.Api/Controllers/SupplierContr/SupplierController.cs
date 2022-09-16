using Microsoft.AspNetCore.Mvc;
using NMMSystem.Aplication.Service;
using NMMSystem.Aplication.Service.SupplierServ;
using NNMSystem.Infrastructure.Dto;

namespace NMMSystem.Api.Controllers.SupplierService
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController: ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpPost("SupplierRegistration")]

        public async Task<ActionResult<ServiceResponce<string>>> SupplierRegistration(SupplierRegistrationDto request)
        {
            return Ok(await _supplierService.SupplierRegistration(request));
        }
        [HttpDelete("DeleteSupplierById")]
        public async Task<ActionResult<ServiceResponce<string>>> DeleteSupplier(int supplierId)
        {
            return Ok(await _supplierService.DeleteSupplier(supplierId));
        }

    }
}
