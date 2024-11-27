using Portfolio.Models;
using Portfolio.Services;

public class UserService : IUserService
{
    private readonly List<User> _users;

    public UserService()
    {
        // Mock user data for simplicity (replace with database logic)
        _users = new List<User>
        {
            new User { Username = "admin", Password = "admin", Role = "Admin" },
            new User { Username = "client", Password = "client", Role = "Client" }
        };
    }

    public User Authenticate(string username, string password)
    {
        // Find user by username and password
        var user = _users.FirstOrDefault(u =>
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
            u.Password == password);

        return user; // Return null if not found
    }
}
