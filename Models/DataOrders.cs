using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiOrder.Models
{
    public class DataOrders {
        public string OrderID { get; set; }

        public DateTime OrderDate { get; set; }
        public string CustomerID { get; set; }

        public DateTime RequiredDate { get; set; }
        public string ShipName { get; set; }

        public decimal TotalPrice { get; set; }

        public string OrderDetailID { get; set; }
        public string ProductID { get; set; }

        public int Qty { get; set; }

        public decimal SubTotal { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
