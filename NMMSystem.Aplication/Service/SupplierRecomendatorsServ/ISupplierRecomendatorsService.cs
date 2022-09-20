using NNMSystem.Infrastructure.Dto.RegistrationSupplierDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Aplication.Service.SupplierRecomendatorsServ
{
    public interface ISupplierRecomendatorsService
    {
        Task<ServiceResponce<string>> AddSupplierRecomendators(SupplierRegistrationDto request);
        
    }
}
