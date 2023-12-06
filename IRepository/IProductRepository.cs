using WebApiOrder.Models;

namespace WebApiOrder.IRepository
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllDataProduct();
    }
}
