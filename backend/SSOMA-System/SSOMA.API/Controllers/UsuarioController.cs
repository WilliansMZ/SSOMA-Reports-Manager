using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSOMA.Domain.Entities;
using SSOMA.Infrastructure.DbContext;

namespace SSOMA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly SsomaDbContext _context;

        public UsuarioController(SsomaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
}