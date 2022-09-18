using NMMSystem.Data.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.Dto.GetAllSupplier
{
    public class GetAllSuplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Picture { get; set; }
        public List<ContactInformationDto> ContactInformation { get; set; }
        public List<PrivateInformationDto> PrivateInformation { get; set; }
        public List<AddressInfoDto> AddressInfo { get; set; }
    }

}
