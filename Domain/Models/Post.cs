namespace Shared.Models;

public class Post
{
    public int Id { get; set; }
    public User Owner { get; }
    public string Title { get; }
    
    public string Body { get; }
  
    

    public Post(User owner, string title)
    {
        Owner = owner;
        Title = title;
    }
}