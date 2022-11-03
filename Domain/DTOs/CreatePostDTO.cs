namespace Shared.DTOs;

public class CreatePostDTO
{
    public int OwnerID { get; set; }
    public string Title { get; set; }
    
    public string Body { get; set; }
  
    

    public CreatePostDTO(int ownerID, string title, string body)
    {
        OwnerID = ownerID;
        Title = title;
        Body = body;
    }
}