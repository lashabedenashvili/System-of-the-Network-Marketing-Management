using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Data.Domein.Data
{
    public class SupplierRecomendators
    {
        public int Id { get; set; }
        public int ReffererSuplier { get; set; }    
        public Supplier RefelalSuplier { get; set; }
    }
}
