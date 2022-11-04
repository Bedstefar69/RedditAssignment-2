using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateUserAsync(CreateUserDTO userToCreate); 
    
    public Task<IEnumerable<User>> GetAsync(GetUsersDTO searchParameter);
}