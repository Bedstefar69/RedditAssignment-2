using System.ComponentModel.DataAnnotations;
using System.Text.Json;
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

    public async Task RegisterUser(User user)
    {
        if (string.IsNullOrEmpty(user.Username))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here

        // save to persistence instead of list

        await userDao.CreateUserAsync(user);
    }
}