using System.Security.Claims;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> Create(CreateUserDTO dto);
    
    
}