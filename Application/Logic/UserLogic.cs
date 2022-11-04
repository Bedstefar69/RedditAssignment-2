using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDAO userDao;

    public UserLogic(IUserDAO userDao)
    {
        this.userDao = userDao;
    }
    
    public async Task<User> CreateUserAsync(CreateUserDTO dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.Username);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        User toCreate = new User
        {
            Username = dto.Username,
            Password = dto.Password
            
        };
    
        User created = await userDao.CreateUserAsync(toCreate);
    
        return created;
    }

    public Task<IEnumerable<User>> GetAsync(GetUsersDTO searchParameter)
    {
        return userDao.GetAsync(searchParameter);
    }

    private static void ValidateData(CreateUserDTO userToCreate)
    {
        string userName = userToCreate.Username;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
    }
}