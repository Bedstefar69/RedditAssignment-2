using Application.DAOInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace FileData.DAOs;

public class PostDAO : IPostDAO
{
    private readonly FileContext context;
    
    public PostDAO(FileContext context)
    {
        this.context = context;
    }
    public Task<Post> CreateAsync(Post post)
    {
        int id = 1;
        if (context.Posts.Any())
        {
            id = context.Posts.Max(t => t.Id);
            id++;
        }

        post.Id = id;
        
        context.Posts.Add(post);
        context.SaveChanges();

        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAsync(GetPostsDTO searchParameter)
    {
        IEnumerable<Post> result = context.Posts.AsEnumerable();

        if (!string.IsNullOrEmpty(searchParameter.Username))
        {
           
            result = context.Posts.Where(post => post.Owner.Username.Equals(searchParameter.Username, StringComparison.OrdinalIgnoreCase));
        }
        
        if (searchParameter.PostId != null)
        {
           
            result = context.Posts.Where(post => post.Id == searchParameter.PostId);
        }

        return Task.FromResult(result);
    }
}