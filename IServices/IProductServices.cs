using WebApiOrder.Models;

namespace WebApiOrder.IServices
{
    public interface IProductServices
    {
        Task<List<Product>> GetAllDataProduct();
    }
}
