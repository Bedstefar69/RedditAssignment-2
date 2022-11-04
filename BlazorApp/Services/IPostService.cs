namespace BlazorApp.Services;

public interface IPostService
{

    public Task createPost(string username, string title, string body);

    public Task getAllPosts();
}