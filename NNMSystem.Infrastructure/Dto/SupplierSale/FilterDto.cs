using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.Dto.SupplierSale
{
    public class FilterDto
    {
        [DataType(DataType.Date)]
        public DateTime? from { get; set; }
        [DataType(DataType.Date)]
        public DateTime? to { get; set; }
        public int? supplierId { get; set; }
        public int? productid { get; set; }
    }
}
