using Shared.Models;

namespace Application.DAOInterfaces;

public interface IUserDAO
{
    Task<User> CreateUserAsync(User user);
    Task<User?> GetByUsernameAsync(string userName);
    
    Task<User?> GetByIdAsync(int id);
}