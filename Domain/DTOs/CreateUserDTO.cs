namespace Shared.DTOs;

public class CreateUserDTO
{
    public string Username { get; set; }
    public string Password { get; set; }
    
    public CreateUserDTO()
    {
       
    }
    public CreateUserDTO(string username, string password)
    {
        Username = username;
        Password = password;
    }
}