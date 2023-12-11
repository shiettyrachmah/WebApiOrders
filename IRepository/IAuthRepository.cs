using WebApiOrder.Models;

namespace WebApiOrder.IRepository
{
    public interface IAuthRepository
    {        
        Task<List<User>> GetAllDataUser();

        Task<User> AddUser(User user);
        Task<User?> GetByUsername(string username);

        Task<User?> GetByUserId(string userId);
    }
}
