using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiOrder.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required(ErrorMessage = "UserName cannot be null")]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password cannot be null")]
        [StringLength(200)]
        public string Password { get; set; }

        [Required(ErrorMessage = "IsAdmin be null")]
        public bool IsAdmin { get; set; }
    }
}
