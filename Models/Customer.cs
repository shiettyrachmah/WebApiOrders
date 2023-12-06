using System.ComponentModel.DataAnnotations;

namespace WebApiOrder.Models
{
    public class Customer 
    {
        [Key]
        [StringLength(5)]
        public string CustomerID { get; set; }

        [Required(ErrorMessage = "CustomerName cannot be null")]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Address cannot be null")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "City cannot be null")]
        [StringLength(20)]
        public string City { get; set; }
    }
}
