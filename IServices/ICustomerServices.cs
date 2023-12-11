using WebApiOrder.Models;

namespace WebApiOrder.IServices
{
    public interface ICustomerServices 
    {
        Task<List<Customer>> GetAllDataCustomer();
    }
}
