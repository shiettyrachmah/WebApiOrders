using WebApiOrder.Models;

namespace WebApiOrder.IRepository
{
    public interface ICustomerRepository
    {        
        Task<List<Customer>> GetAllDataCustomer();
    }
}
