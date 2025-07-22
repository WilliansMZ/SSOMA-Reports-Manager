using MediatR;
using SSOMA.Application.DTOs.Users;

namespace SSOMA.Application.Features.Users.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<RegisterUserResponseDto>
{
    public RegisterUserRequestDto User { get; set; }
    public RegisterUserCommand(RegisterUserRequestDto user)
    {
        User = user;
    }
}