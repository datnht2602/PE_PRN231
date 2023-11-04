using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Roles
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Role_Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Rol_Desc { get; set; }
        public ICollection<Users>? Users { get; set; }
    }
}