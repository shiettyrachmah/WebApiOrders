using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiOrder.Models
{
    public class OrderHeader
    {
        [Key]
        [StringLength(10)]
        public string OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "CustomerID cannot be null")]
        [StringLength(5)]
        public string CustomerID { get; set; }

        public DateTime RequiredDate { get; set; }

        [Required(ErrorMessage = "ShipName cannot be null")]
        [StringLength(20)]
        public string ShipName { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalPrice { get; set; }
    }
}
