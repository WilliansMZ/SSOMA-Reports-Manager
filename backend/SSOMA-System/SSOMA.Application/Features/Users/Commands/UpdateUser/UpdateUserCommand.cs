using MediatR;

namespace SSOMA.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<bool>
{
    public int Id { get; set; } // ID del usuario a actualizar
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string NationalId { get; set; } = null!;
    public int RoleId { get; set; }
}