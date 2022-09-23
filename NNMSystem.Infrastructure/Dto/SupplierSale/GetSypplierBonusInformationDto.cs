using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.Dto.SupplierSale
{
    public class GetSypplierBonusInformationDto
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Bonus { get; set; }
    }
}
