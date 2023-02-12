namespace Core.Security.Dtos;

public class UserForLoginDto
{
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string? AuthenticatorCode { get; set; }
}