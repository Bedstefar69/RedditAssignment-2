using System.Net.Http.Json;
using Shared.DTOs;

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
}