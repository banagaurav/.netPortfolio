using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserByUsername(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<bool> RegisterUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
    }
}
