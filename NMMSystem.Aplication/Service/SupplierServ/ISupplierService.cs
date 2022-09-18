using NMMSystem.Data.Domein;
using NNMSystem.Infrastructure.Dto;
using NNMSystem.Infrastructure.Dto.GetAllSupplier;
using NNMSystem.Infrastructure.Dto.RegistrationSupplierDto;
using NNMSystem.Infrastructure.Dto.UpdateSupplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Aplication.Service.SupplierServ
{
    public interface ISupplierService
    {
        Task<ServiceResponce<string>> SupplierRegistration(SupplierRegistrationDto request);
        Task<ServiceResponce<string>> DeleteSupplier(int supplierId);
        Task<ServiceResponce<string>> UpdateSupplier(UpdateSupplierDto request);
        Task<ServiceResponce<List<GetAllSuplierDto>>> GetSupplier();
    }
}
