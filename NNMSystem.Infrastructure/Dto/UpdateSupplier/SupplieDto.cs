using NMMSystem.Data.Domein;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.Dto.UpdateSupplier
{
    public class SupplieDto
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }

        public string SurName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }
        public string Picture { get; set; }
    }
}
