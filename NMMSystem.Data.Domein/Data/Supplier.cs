using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NMMSystem.Data.Domein
{
    public class Supplier
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string SurName { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public string Picture { get; set; }
        public List<PrivateInformation> PrivateInfromations { get; set; } = new();
        public List<ContactInformation> ContactInfromations { get; set; } = new();
        public List<AddressInfo> AddressInfromations { get; set; } = new();

    }
}