using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace SSOMA.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected int GetUserId()
    {
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId");

        if (userIdClaim == null)
        {
            // Para debug: mostrar todos los claims si hay error
            var claimsDump = string.Join(", ", User.Claims.Select(c => $"{c.Type}: {c.Value}"));
            throw new UnauthorizedAccessException($"User ID not found in JWT token. Claims: {claimsDump}");
        }

        return int.Parse(userIdClaim.Value);
    }
}