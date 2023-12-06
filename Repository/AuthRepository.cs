using Microsoft.EntityFrameworkCore;
using WebApiOrder.DBContext;
using WebApiOrder.IRepository;
using WebApiOrder.Models;

namespace WebApiOrder.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDBContext _db;

        public AuthRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<List<User>> GetAllDataUser()
        {
            return await _db.User.ToListAsync();
        }

        public async Task<User> AddUser(User user)
        {
            _db.User.Add(user);
            await _db.SaveChangesAsync();

            return user;
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _db.User.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<User?> GetByUserId(string userId)
        {
            return await _db.User.FirstOrDefaultAsync(x => x.UserID.ToString() == userId);
        }
    }
}
