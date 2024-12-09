using Portfolio.Models;

public interface IUserRepository
{
    Task<User?> GetUserByUsernameAsync(string username);
    Task<bool> RegisterUserAsync(User user);
}
