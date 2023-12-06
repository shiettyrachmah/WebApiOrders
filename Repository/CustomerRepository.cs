using Microsoft.EntityFrameworkCore;
using WebApiOrder.DBContext;
using WebApiOrder.IRepository;
using WebApiOrder.Models;

namespace WebApiOrder.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDBContext _db;
        public CustomerRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<List<Customer>> GetAllDataCustomer()
        {
            return await _db.Customer.ToListAsync();
        }


    }
}
