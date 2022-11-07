using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task CreateAsync(CreatePostDTO dto);
    
    Task<GetPostsDTO> GetByIdAsync(int id);
    Task<ICollection<Post>> GetAsync(
        string? username,
        int? postId
    );
}