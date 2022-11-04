using Application.DAOInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace FileData.DAOs;

public class UserFileDAO : IUserDAO
{
    
    private readonly FileContext context;

    public UserFileDAO(FileContext context)
    {
        this.context = context;
    }
    public Task<User> CreateUserAsync(User user)
    {
        int userId = 1;
        if (context.Users.Any())
        {
            userId = context.Users.Max(u => u.Id);
            userId++;
        }

        user.Id = userId;

        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string userName)
    {
        User? existing = context.Users.FirstOrDefault(u =>
            u.Username.Equals(userName, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }
    
    public Task<User?> GetByIdAsync(int id)
    {
        User? existing = context.Users.FirstOrDefault(u =>
            u.Id == id
        );
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<User>> GetAsync(GetUsersDTO searchParameters)
    {
        IEnumerable<User> users = context.Users.AsEnumerable();
        if (searchParameters.UsernameContains != null)
        {
            users = context.Users.Where(u => u.Username.Contains(searchParameters.UsernameContains, StringComparison.OrdinalIgnoreCase));
        }
        return Task.FromResult(users);
    }
}