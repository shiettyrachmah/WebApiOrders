using WebApiOrder.Models;

namespace WebApiOrder.IRepository
{
    public interface ICustomerRepository
    {        
        public Task<List<Customer>> GetAllDataCustomer();
    }
}
