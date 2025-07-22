using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSOMA.Application.DTOs.Login;
using SSOMA.Application.DTOs.Users;
using SSOMA.Application.Features.Login;
using SSOMA.Application.Features.Login.Commands;
using SSOMA.Application.Features.Users.Commands.RegisterUser;

namespace SSOMA.API.Controllers.Auth;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        var response = await _mediator.Send(new LoginUserCommand(request));
        return Ok(response);
    }
    
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequestDto request)
    {
        var command = new RegisterUserCommand(request);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
