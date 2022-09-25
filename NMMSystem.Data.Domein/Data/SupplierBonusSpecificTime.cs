using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Data.Domein.Data
{
    public class SupplierBonusSpecificTime
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Bonus { get; set; }
        public Supplier Supplier { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateTimeFrom { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateTimeTo { get; set; }        
        public bool TimePeriodBool { get; set; } = true;

    }
}
