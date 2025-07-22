using MediatR;
using SSOMA.Application.DTOs.Login;

namespace SSOMA.Application.Features.Login.Commands;

public record LoginUserCommand(LoginRequestDto Request) : IRequest<LoginResponseDto>;
