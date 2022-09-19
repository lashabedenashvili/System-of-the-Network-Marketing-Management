using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.Dto.SupplierSale
{
    public class FilterDto
    {
        public DateTime? from { get; set; }
        public DateTime? to { get; set; }
        public int? supplierId { get; set; }
        public int? productid { get; set; }
    }
}
