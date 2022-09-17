using NMMSystem.Data.Domein.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.Dto.UpdateSupplier
{
    public class UpdateContactInformationDto
    {
        public ContactInformationType ContactInformationType { get; set; }
        public string ContactInfo { get; set; }
    }
}
