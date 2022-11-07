using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(CreatePostDTO dto);

    Task<IEnumerable<Post>> GetAsync(GetPostsDTO searchParameter);
}