using NNMSystem.Infrastructure.Dto.AddProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.Dto.SupplierSale
{
    public class GetSupplierSalebysupplierDto
    {
        public int SupplierId { get; set; }
        public int ProductId { get; set; }        
        public DateTime SaleTime { get; set; }
        public decimal ProductPrise { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public AddProductDto ProductDto { get; set; }    
    }
}
