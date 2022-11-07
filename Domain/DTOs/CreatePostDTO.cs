namespace Shared.DTOs;

public class CreatePostDTO
{
    public string Username { get; set; }
    public string Title { get; set; }
    
    public string Body { get; set; }
  
    

    public CreatePostDTO(string username, string title, string body)
    {
        Username = username;
        Title = title;
        Body = body;
    }
}