namespace SSOMA.Application.DTOs.Users;

public class UserCreateDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string NationalId { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string Password { get; set; } = null!;
}