namespace Shared.DTOs;

public class GetOnePostDTO
{
   
    public int PostId { get; }


    public GetOnePostDTO(int postId)
    {
        PostId = postId;
    }
}