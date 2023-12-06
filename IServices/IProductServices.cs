using WebApiOrder.Models;

namespace WebApiOrder.IServices
{
    public interface IProductServices
    {
        public Task<List<Product>> GetAllDataProduct();
    }
}
