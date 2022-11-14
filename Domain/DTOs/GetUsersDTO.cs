namespace Shared.DTOs;

public class GetUsersDTO
{
    public string? UsernameContains { get;  }

    public GetUsersDTO(string? usernameContains)
    {
        UsernameContains = usernameContains;
       

    }
}