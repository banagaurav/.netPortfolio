using Portfolio.Data;
using Portfolio.Models;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> RegisterUser(User user)
    {
        try
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
