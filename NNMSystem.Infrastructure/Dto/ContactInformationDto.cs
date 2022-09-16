using NMMSystem.Data.Domein.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.Dto
{
    public class ContactInformationDto
    {
        public ContactInformationType ContactInformationType { get; set; }       
        public string ContactInfo { get; set; }
       
    }
}
