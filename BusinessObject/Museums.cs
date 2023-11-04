using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Museums
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Museum_Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Museum_Name { get; set; } = null!;
        [Required]
        [StringLength(225)]
        public string Address { get; set; } = null!;
        public ICollection<Artworks>? Artworks { get; set; }
    }
}