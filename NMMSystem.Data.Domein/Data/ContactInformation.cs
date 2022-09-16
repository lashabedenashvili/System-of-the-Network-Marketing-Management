using NMMSystem.Data.Domein.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Data.Domein
{
    public class ContactInformation
    {
        public int Id { get; set; }
     
        [Required]  
        public ContactInformationType ContactInformationType { get; set; }
        [Required]
        [MaxLength(100)]
        public string ContactInfo { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }


    }
}
