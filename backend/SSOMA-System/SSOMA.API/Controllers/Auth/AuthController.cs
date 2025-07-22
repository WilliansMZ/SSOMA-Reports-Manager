using MediatR;
using Microsoft.AspNetCore.Mvc;
using SSOMA.Application.DTOs.Login;
using SSOMA.Application.Features.Login;
using SSOMA.Application.Features.Login.Commands;

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
}
