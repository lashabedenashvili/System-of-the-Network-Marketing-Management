using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Data.Domein
{
    public class AddressInfo
    {
        public int Id { get; set; }
        public string ActualAddress { get; set; }
        public string RegistrationAddress { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
