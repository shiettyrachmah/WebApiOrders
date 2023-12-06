using Microsoft.EntityFrameworkCore;
using WebApiOrder.Models;

namespace WebApiOrder.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {}

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<OrderHeader> OrderHeader { get; set; }

        public virtual DbSet<OrderDetail> OrderDetail { get; set; }



    }
}
