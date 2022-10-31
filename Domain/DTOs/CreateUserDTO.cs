namespace Shared.DTOs;

public class CreateUserDTO
{
    public string Username { get;}
    public string Password { get;}

    public CreateUserDTO(string username, string password)
    {
        Username = username;
        Password = password;
    }
}