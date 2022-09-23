using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.Dto.SupplierSale
{
  
   public class SypplierBonusSystemFilterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal? BonusMin { get; set; }
        public decimal? BonusMax { get; set; }
    }
}
