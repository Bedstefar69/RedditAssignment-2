using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Newtonsoft.Json;
using Shared.Models;

namespace WebAPI.Services;

public class AuthService : IAuthService
{

    public IList<User> getFile()
    {

        string fileName = "data.json";
        string jsonString = File.ReadAllText(fileName);
        User? user = JsonConvert.DeserializeObject<User>(jsonString); 

        IList<User> users = new List<User>();
        
         users.Add(user);
         Console.WriteLine(users.ToString());
         return users;
    }


    public Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = getFile().FirstOrDefault(u => 
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
        
        getFile().Add(user);
        
        return Task.CompletedTask;
    }
    }
