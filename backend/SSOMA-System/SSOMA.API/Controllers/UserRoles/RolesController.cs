using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSOMA.Application.Features.UserRoles.Queries;

namespace SSOMA.API.Controllers.UserRoles;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Puedes protegerlo si deseas solo para ssoma_manager:
    [HttpGet]
    //[Authorize(Roles = "ssoma_manager")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> GetRoles()
    {
        var result = await _mediator.Send(new GetRolesQuery());
        return Ok(result);
    }
}