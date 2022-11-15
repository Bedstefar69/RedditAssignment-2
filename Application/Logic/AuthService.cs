using Application.DAOInterfaces;
using Shared.Models;

namespace Application.Logic;

public class AuthService : IAuthService

{
    private readonly IUserDAO userDao;

    public AuthService(IUserDAO userDao)
    {
        this.userDao = userDao;
    }
    
    
    public async Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = await userDao.GetByUsernameAsync(username);

        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }
    
}