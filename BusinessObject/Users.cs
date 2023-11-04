using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Users
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email_Address { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Password { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Roles? Roles { get; set; }
        [Required]
        public int Artwork_Id { get; set; }
        [ForeignKey("Artwork_Id")]
        public Artworks? Artworks { get; set; }
    }
}
