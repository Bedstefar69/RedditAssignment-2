using Shared.DTOs;
using Shared.Models;

namespace Application.DAOInterfaces;

public interface IPostDAO
{
    Task<Post> CreateAsync(Post post);
    
    Task<IEnumerable<Post>> GetAsync(GetPostsDTO searchParameter);
}