using NMMSystem.Data.Domein;
using NMMSystem.Data.Domein.Data.Enum;
using NMMSystem.Data.Domein.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.Dto
{
    public class SupplierRegistrationDto
    {
        public SupplierDto Supplier { get; set; }
        public ContactInformationDto ContactInformation { get; set; }
        public PrivateInformationDto PrivateInformation { get; set; }
        public AddressInfoDto AddressInfo { get; set; }
    }
}
