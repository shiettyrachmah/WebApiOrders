using System.Data;
using WebApiOrder.IRepository;
using WebApiOrder.IServices;
using WebApiOrder.Models;

namespace WebApiOrder.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IAuthRepository _repo;
        public AuthServices(IAuthRepository repo)
        {
            _repo = repo;
        }
        public Task<User> AddUser(User user)
        {
           return _repo.AddUser(user);
        }

        public Task<List<User>> GetAllDataUser()
        {
            return _repo.GetAllDataUser();
        }

        public Task<User?> GetByUserId(string userId)
        {
            return _repo.GetByUserId(userId);
        }

        public Task<User?> GetByUsername(string username)
        {
            return _repo.GetByUsername(username);
        }
    }
}
