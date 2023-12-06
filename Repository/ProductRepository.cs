using Microsoft.EntityFrameworkCore;
using WebApiOrder.DBContext;
using WebApiOrder.IRepository;
using WebApiOrder.Models;

namespace WebApiOrder.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _db;

        public ProductRepository(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<List<Product>> GetAllDataProduct()
        {
            return await _db.Product.ToListAsync();
        }
    }
}
