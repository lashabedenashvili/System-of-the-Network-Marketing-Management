using NMMSystem.Data.Domein.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.Dto
{
    public class AddressInfoDto
    {
        public AddressType AddressType { get; set; }      
        public string Address { get; set; }
    }
}
