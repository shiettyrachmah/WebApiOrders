using WebApiOrder.Models;

namespace WebApiOrder.IServices
{
    public interface IAuthServices
    {
        public Task<List<User>> GetAllDataUser();

        public Task<User> AddUser(User user);
        public Task<User?> GetByUsername(string username);

        public Task<User?> GetByUserId(string userId);
    }
}
