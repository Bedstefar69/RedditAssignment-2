using System.Net.Http.Json;
using System.Text.Json;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces.Implementations;

public class UserHttpClient : IUserService
{
    private readonly HttpClient client;

    public UserHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<User> Create(CreateUserDTO dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/User", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return user;
    }
    
}