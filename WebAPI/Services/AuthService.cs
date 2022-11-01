using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using FileData;
using Shared.Models;

namespace WebAPI.Services;

public class AuthService : IAuthService

{
    private IList<User> ReadFile()
    {
        string jsonString = File.ReadAllText(@"./data.json");
        DataContainer dc = JsonSerializer.Deserialize<DataContainer>(jsonString);
        return dc.Users.ToList();
    }

    
    public Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = ReadFile().FirstOrDefault(u =>
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingUser);
    }

    public Task RegisterUser(User user)
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

        ReadFile().Add(user);

        return Task.CompletedTask;
    }
}