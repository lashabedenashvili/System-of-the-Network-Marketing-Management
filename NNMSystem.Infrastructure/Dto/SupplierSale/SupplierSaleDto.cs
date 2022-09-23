using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.Dto.AddProduct
{
    public class SupplierSaleDto
    {
        public int SupplierId { get; set; }
        public int ProductId { get; set; }
        [DataType(DataType.Date)]
        public DateTime SaleTime { get; set; }
        public decimal ProductPrise { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
