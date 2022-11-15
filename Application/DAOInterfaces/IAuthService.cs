using Shared.Models;

namespace Application.DAOInterfaces;

public interface IAuthService
{
    Task<User> ValidateUser(string username, string password);
    Task RegisterUser(User user);
}