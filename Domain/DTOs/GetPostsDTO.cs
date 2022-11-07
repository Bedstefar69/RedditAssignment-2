
namespace Shared.DTOs;

public class GetPostsDTO
{
    public string? Username;
    public int? PostId;


    public GetPostsDTO(string? username, int? postId)
    {
        Username = username;
        PostId = postId;
    }
    
    public GetPostsDTO( int? postId)
    {
       
        PostId = postId;
    }
}