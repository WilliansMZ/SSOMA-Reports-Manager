using Microsoft.AspNetCore.Mvc;
using SSOMA.Infrastructure.DbContext;

namespace SSOMA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly SsomaDbContext _context;

        public HealthCheckController(SsomaDbContext context)
        {
            _context = context;
        }

        [HttpGet("db-status")]
        public async Task<IActionResult> GetDbStatus()
        {
            var canConnect = await _context.Database.CanConnectAsync();
            if (canConnect)
                return Ok("✅ Conexión con la base de datos exitosa.");
            else
                return StatusCode(500, "❌ No se pudo conectar con la base de datos.");
        }
    }
}