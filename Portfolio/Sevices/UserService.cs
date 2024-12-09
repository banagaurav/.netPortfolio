using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;


namespace Portfolio.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> RegisterUserAsync(RegisterViewModel model)
        {
            // Validate and handle user registration logic here
            var existingUser = await _userRepository.GetUserByUsernameAsync(model.Username);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Username already exists.");
            }

            var user = new User
            {
                Username = model.Username,
                Password = model.Password,  // You can hash the password here.
                Role = model.Role
            };

            return await _userRepository.RegisterUserAsync(user);
        }

        public async Task<User?> ValidateUserAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            if (user == null || user.Password != password) // Ensure proper password hashing in production
                return null;

            return user;
        }

    }
}
