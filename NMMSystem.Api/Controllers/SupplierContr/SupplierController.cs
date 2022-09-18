using Microsoft.AspNetCore.Mvc;
using NMMSystem.Aplication.Service;
using NMMSystem.Aplication.Service.SupplierServ;
using NMMSystem.Data.Domein;
using NNMSystem.Infrastructure.Dto;
using NNMSystem.Infrastructure.Dto.GetAllSupplier;
using NNMSystem.Infrastructure.Dto.RegistrationSupplierDto;
using NNMSystem.Infrastructure.Dto.UpdateSupplier;

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

        [HttpPost("UpdateSupplierById")]

        public async Task<ActionResult<ServiceResponce<string>>> UpdateSupplierById(UpdateSupplierDto request)
        {
            return Ok(await _supplierService.UpdateSupplier(request));
        }
       
        [HttpGet("GetAllSuplier")]
        public async Task<ActionResult<List<GetAllSuplierDto>>> GetSupplier()
        {
            return Ok(await _supplierService.GetSupplier());
        }



    }
}
