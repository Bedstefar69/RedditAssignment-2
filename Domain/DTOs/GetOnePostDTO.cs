namespace Shared.DTOs;

public class GetOnePostDTO
{
    public string Username { get; }
    public int PostId { get; }


    public GetOnePostDTO(string username, int postId)
    {
        Username = username;
        PostId = postId;
    }
}