using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Data.Domein.Data
{
    public class SupplierRecomendators
    {
        public int Id { get; set; }


        
        public int RecommenderSupplierId { get; set; }        
        public Supplier RecommenderSupplier { get; set; }

        [ForeignKey("RecommendedSupplierId")]
        public int RecommendedSupplierId { get; set; }
        public Supplier RecommendedSupplier { get; set; } 
        
    }
}
