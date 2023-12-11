using WebApiOrder.Models;

namespace WebApiOrder.IRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllDataProduct();
    }
}
