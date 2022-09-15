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
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        [Required]
        [MaxLength(100)]
        public string ContactInfo { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }


    }
}
