using MediatR;

namespace SSOMA.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<bool>
{
    public int Id { get; }

    public DeleteUserCommand(int id)
    {
        Id = id;
    }
}