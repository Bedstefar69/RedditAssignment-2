
namespace Shared.DTOs;

public class GetPostsDTO
{
    public string? Username;
    public int? PostId;
    public int? UserId;


    public GetPostsDTO(string? username, int? postId, int? userId)
    {
        Username = username;
        PostId = postId;
        UserId = userId;
    }
    
  
}