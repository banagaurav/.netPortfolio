using Portfolio.Models;

namespace Portfolio.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterViewModel model);
        Task<User?> ValidateUserAsync(string username, string password);
    }
}
