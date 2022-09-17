using AutoMapper;
using NMMSystem.Data.Domein;
using NNMSystem.Infrastructure.Dto.UpdateRegistration;
using NNMSystem.Infrastructure.Dto.UpdateSupplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.AutoMapper
{
    public class UpdateAutoMapperProfile:Profile
    {
        public UpdateAutoMapperProfile()
        {
            CreateMap<SupplieDto,Supplier>()
                .ForAllMembers(c => c.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<UpdateAddressInfoDto,AddressInfo >()
                .ForAllMembers(c => c.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UpdateContactInformationDto,ContactInformation >()
                .ForAllMembers(c => c.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UpdatePrivateInformationDto,PrivateInformation >()
                .ForAllMembers(c => c.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
