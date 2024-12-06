using Portfolio.Models;
using System.Threading.Tasks;

namespace Portfolio.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> RegisterUser(User user);
        Task<User> LoginUser(string username, string password);
    }
}
