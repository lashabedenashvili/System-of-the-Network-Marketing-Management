using NNMSystem.Infrastructure.Dto.UpdateRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.Dto.UpdateSupplier
{
    public class UpdateSupplierDto
    {

        public SupplieDto SupplieDto { get; set; }
        public UpdateAddressInfoDto UpdateAddressInfoDto { get; set; }
        public UpdateContactInformationDto UpdateContactInformationDto { get; set; }
        public UpdatePrivateInformationDto UpdatePrivateInformationDto { get; set; }
    }
}
