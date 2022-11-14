using Application.DAOInterfaces;
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

    public Task<IEnumerable<Post>> GetAsync(GetPostsDTO searchParameter)
    {
        throw new NotImplementedException();
    }
}