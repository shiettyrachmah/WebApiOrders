using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiOrder.Models
{
    public class Product
    {
        [Key]
        [StringLength(10)]
        public string ProductID { get; set; }

        [Required(ErrorMessage = "ProductName cannot be null")]
        [StringLength(20)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price cannot be null")]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Price { get; set; }
    }
}
