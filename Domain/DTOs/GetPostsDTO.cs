
namespace Shared.DTOs;

public class GetPostsDTO
{
    public string? Username;


    public GetPostsDTO(string? username)
    {
        Username = username;
    }
}