using Application.DAOInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.DTOs;
using Shared.Models;

namespace EFCDataAccess.DAOs;

public class PostEfcDao : IPostDAO
{
    
    private readonly PostContext context;

    public PostEfcDao(PostContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> added = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync(GetPostsDTO searchParameter)
    {
        IQueryable<Post> query = context.Posts.Include(post => post.Owner).AsQueryable();
    
        if (!string.IsNullOrEmpty(searchParameter.Username))
        {
            query = query.Where(post =>
                post.Owner.Username!.ToLower().Equals(searchParameter.Username.ToLower()));
        }
    
        if (searchParameter.UserId != null)
        {
            query = query.Where(p => p.Owner.Id == searchParameter.UserId);
        }
        
        if (searchParameter.PostId != null)
        {
            query = query.Where(p => p.Id == searchParameter.PostId);
        }
        
    
       

        List<Post> result = await query.ToListAsync();
        return result;
    }
}