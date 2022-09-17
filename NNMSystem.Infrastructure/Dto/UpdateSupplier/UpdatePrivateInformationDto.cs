using NMMSystem.Data.Domein.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.Dto.UpdateSupplier
{
    public class UpdatePrivateInformationDto
    {
        public DocumentType DocumenType { get; set; }


        public string DocumentNumber { get; set; }


        public string SerialNumber { get; set; }

        public DateTime DateIssue { get; set; }

        public DateTime DateExpiry { get; set; }

        public string PrivateNumber { get; set; }

        public string IssuingAutority { get; set; }
    }
}
