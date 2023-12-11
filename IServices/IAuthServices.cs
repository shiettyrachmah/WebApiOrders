using WebApiOrder.Models;

namespace WebApiOrder.IServices
{
    public interface IAuthServices
    {
        Task<List<User>> GetAllDataUser();

        Task<User> AddUser(User user);
        Task<User?> GetByUsername(string username);

        Task<User?> GetByUserId(string userId);
    }
}
