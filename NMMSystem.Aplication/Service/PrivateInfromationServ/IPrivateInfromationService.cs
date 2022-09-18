using NMMSystem.Data.Domein;
using NNMSystem.Infrastructure.Dto;
using NNMSystem.Infrastructure.Dto.UpdateSupplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Aplication.Service.PrivateInfromationServ
{
    public interface IPrivateInfromationService
    {
        Task<ServiceResponce<string>>AddPrivateInformation(PrivateInformationDto request,Supplier supplier);
        Task<ServiceResponce<string>> DeletePrivateInformationBySupplierId(int supplierId);
        Task<ServiceResponce<string>> UpdatePrivateInformation(UpdateSupplierDto request);
      
    }
}
