using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiOrder.Models
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailID { get; set; }

        [Required(ErrorMessage = "OrderID cannot be null")]
        [StringLength(10)]
        public string OrderID { get; set; }

        [StringLength(10)]
        public string ProductID { get; set; }

        public int Qty { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal SubTotal { get; set; }
    }
}
