using System.Data;
using WebApiOrder.IRepository;
using WebApiOrder.IServices;
using WebApiOrder.Models;

namespace WebApiOrder.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _repo;

        public CustomerServices(ICustomerRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Customer>> GetAllDataCustomer()
        {
            return await _repo.GetAllDataCustomer();
        }
    }
}
