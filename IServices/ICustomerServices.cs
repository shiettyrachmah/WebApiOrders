using WebApiOrder.Models;

namespace WebApiOrder.IServices
{
    public interface ICustomerServices 
    {
        public Task<List<Customer>> GetAllDataCustomer();
    }
}
