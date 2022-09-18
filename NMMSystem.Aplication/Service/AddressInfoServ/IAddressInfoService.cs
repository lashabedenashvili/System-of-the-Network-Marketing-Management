using NMMSystem.Data.Domein;
using NNMSystem.Infrastructure.Dto;
using NNMSystem.Infrastructure.Dto.UpdateSupplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Aplication.Service.AddressInfoServ
{
    public interface IAddressInfoService
    {
        Task<ServiceResponce<string>> AddAddressInfo(AddressInfoDto request, Supplier supplier);
        Task<ServiceResponce<string>> DeleteAddressBySupplierId(int supplierId);
        Task<ServiceResponce<string>> UpdateAddressInfo(UpdateSupplierDto request);
        
    }
}
