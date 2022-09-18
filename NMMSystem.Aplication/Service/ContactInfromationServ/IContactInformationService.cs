using NMMSystem.Data.Domein;
using NNMSystem.Infrastructure.Dto;
using NNMSystem.Infrastructure.Dto.UpdateSupplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Aplication.Service.ContactInfromationServ
{
    public interface IContactInformationService
    {
        Task<ServiceResponce<string>> AddContactInformation(ContactInformationDto request,Supplier supplier);
        Task<ServiceResponce<string>> DeleteContactInformationBySupplierId(int supplierId);
        Task<ServiceResponce<string>> UpdateContactInformation(UpdateSupplierDto request);
       
    }
}
