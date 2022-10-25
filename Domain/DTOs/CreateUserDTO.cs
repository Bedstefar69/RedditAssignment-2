namespace Shared.DTOs;

public class CreateUserDTO
{
    public string UserName { get;}
    public string Password { get;}

    public CreateUserDTO(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}