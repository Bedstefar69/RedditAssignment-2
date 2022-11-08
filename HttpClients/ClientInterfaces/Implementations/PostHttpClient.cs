using System.Net.Http.Json;
using System.Text.Json;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces.Implementations;

public class PostHttpClient : IPostService
{
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }
    public async Task CreateAsync(CreatePostDTO dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/Post",dto);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<GetPostsDTO> GetByIdAsync(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"/post/{id}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        GetPostsDTO post = JsonSerializer.Deserialize<GetPostsDTO>(content, 
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        )!;
        return post;
    }

    public async Task<ICollection<Post>> GetAsync(string? username, int? postId)
    {
        string query = ConstructQuery(username, postId);
        

        HttpResponseMessage response = await client.GetAsync("/Post" + query);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }
    
    private static string ConstructQuery(string? userName, int? postId)
    {
        string query = "";
        if (!string.IsNullOrEmpty(userName))
        {
            query += $"?username={userName}";
        }
        
        
        if (postId != null)
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"postId={postId}";
        }
        Console.WriteLine(query);

        return query;
    }
}