namespace SSOMA.Application.DTOs.Users;

public class RegisterUserRequestDto
{
    public string Email { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string NationalId { get; set; } = default!; // <- Este campo debe existir
    public string Password { get; set; } = default!;
    public int RoleId { get; set; }
}
