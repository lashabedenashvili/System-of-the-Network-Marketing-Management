using Castle.MicroKernel.SubSystems.Conversion;
using NMMSystem.Data.Domein.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Data.Domein
{
    public class PrivateInformation
    {
        public int Id { get; set; }
        [Required]
        public DocumentType DocumenType { get; set; }
   
        [MaxLength(10)]
        public string DocumentNumber { get; set; }
      
        [MaxLength(10)]
        public string SerialNumber { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime DateIssue { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime DateExpiry { get; set; }
        [Required]
        [MaxLength(50)]
        public string PrivateNumber { get; set; }

        [MaxLength(100)]
        public string IssuingAutority { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
