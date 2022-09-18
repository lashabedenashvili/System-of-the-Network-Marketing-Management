using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.Dto.AddProduct
{
    public class AddProductDto
    {
        public string Name { get; set; }
        public string BarCode { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
