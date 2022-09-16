using NNMSystem.Infrastructure.Dto;
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
    }
}
