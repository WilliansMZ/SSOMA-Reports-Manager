namespace SSOMA.Application.DTOs.Users;

public class UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string NationalId { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string? Status { get; set; }
}