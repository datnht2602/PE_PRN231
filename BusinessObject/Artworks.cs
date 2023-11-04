using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Artworks
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Artwork_Id { get; set; }
        [Required]
        [StringLength(50)]
        public string NameAtWork { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Description { get; set; } = null!;
        [Column(TypeName ="money")]
        public decimal Price { get; set; }
        [Required]
        public int Museum_Id { get; set; }
        [ForeignKey("Museum_Id")]
        public Museums? Museums { get; set; }
    }
}