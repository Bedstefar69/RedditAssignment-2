using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDAO postDao;
    private readonly IUserDAO userDao;

    public PostLogic(IPostDAO postDao, IUserDAO userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }

    public async Task<Post> CreateAsync(CreatePostDTO dto)
    {
        User? user = await userDao.GetByUsernameAsync(dto.Username);
        if (user == null)
        {
            throw new Exception($"User with username {dto.Username} was not found.");
        }

        ValidatePost(dto);
        Post post = new Post(user, dto.Title, dto.Body);
        Post created = await postDao.CreateAsync(post);
        return created;
    }

    public Task<IEnumerable<Post>> GetAsync(GetPostsDTO searchParameter)
    {
        return postDao.GetAsync(searchParameter);
    }

    private void ValidatePost(CreatePostDTO dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(dto.Body)) throw new Exception("Body cannot be empty.");
        
    }
    
}