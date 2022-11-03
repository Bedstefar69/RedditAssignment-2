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
        User? user = await userDao.GetByIdAsync(dto.OwnerID);
        if (user == null)
        {
            throw new Exception($"User with id {dto.OwnerID} was not found.");
        }

        ValidateTodo(dto);
        Post post = new Post(user, dto.Title, dto.Body);
        Post created = await postDao.CreateAsync(post);
        return created;
    }
    
    private void ValidateTodo(CreatePostDTO dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        // other validation stuff
    }
}