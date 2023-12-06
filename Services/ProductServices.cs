using WebApiOrder.IRepository;
using WebApiOrder.IServices;
using WebApiOrder.Models;

namespace WebApiOrder.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _repo;
        public ProductServices(IProductRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Product>> GetAllDataProduct()
        {
            return await _repo.GetAllDataProduct();
        }
    }
}
