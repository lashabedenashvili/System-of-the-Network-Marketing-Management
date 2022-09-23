using System;
using System.Collections.Generic;
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
        [Column(TypeName = "Date")]
        public DateTime DateTimeFrom { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DateTimeTo { get; set; }
    }
}
