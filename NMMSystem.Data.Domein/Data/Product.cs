using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Data.Domein.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BarCode { get; set; }
        public decimal UnitPrice { get; set; }
        public List<SupplierSale> SupplierSale { get; set; }=new();
    }
}
