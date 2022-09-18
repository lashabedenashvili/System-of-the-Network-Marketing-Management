using AutoMapper;
using NMMSystem.Data.Domein;
using NNMSystem.Infrastructure.Dto;
using NNMSystem.Infrastructure.Dto.GetAllSupplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.AutoMapper
{
    public class SupplierAutoMapperProfile : Profile
    {
        public SupplierAutoMapperProfile()
        {
            CreateMap<Supplier, GetAllSuplierDto>()
                .ForMember(e => e.AddressInfo, opt => opt.MapFrom(s => s.AddressInfromations))
                .ForMember(e => e.ContactInformation, opt => opt.MapFrom(s => s.ContactInfromations))
                .ForMember(e => e.PrivateInformation, opt => opt.MapFrom(s => s.PrivateInfromations));

            CreateMap<PrivateInformation, PrivateInformationDto>();
            CreateMap<ContactInformation, ContactInformationDto>();
            CreateMap<AddressInfo, AddressInfoDto>();




        }
    }
}
