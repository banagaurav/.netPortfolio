using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.Repositories.Interfaces;


namespace Portfolio.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> RegisterUser(User user)
        {
            if (await _db.Users.AnyAsync(u => u.Username == user.Username))
            {
                return false; // Username already exists
            }
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<User> LoginUser(string username, string password)
        {
            return await _db.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
    }
}
