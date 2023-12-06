using WebApiOrder.Models;

namespace WebApiOrder.IRepository
{
    public interface IAuthRepository
    {        
        public Task<List<User>> GetAllDataUser();

        public Task<User> AddUser(User user);
        public Task<User?> GetByUsername(string username);

        public Task<User?> GetByUserId(string userId);
    }
}
