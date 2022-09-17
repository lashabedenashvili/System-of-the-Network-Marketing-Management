using AutoMapper;
using NMMSystem.Data.Domein;
using NNMSystem.Infrastructure.Dto;
using NNMSystem.Infrastructure.Dto.RegistrationSupplierDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.AutoMapper
{
    public class RegistrationAutoMapperProfile:Profile
    {
        public RegistrationAutoMapperProfile()
        {
            CreateMap<SupplierDto, Supplier>();
            CreateMap<PrivateInformationDto, PrivateInformation>();
            CreateMap<AddressInfoDto, AddressInfo>();
            CreateMap<ContactInformationDto, ContactInformation>();
            CreateMap<SupplierRegistrationDto, SupplierDto>();
            
        }
    }
}
