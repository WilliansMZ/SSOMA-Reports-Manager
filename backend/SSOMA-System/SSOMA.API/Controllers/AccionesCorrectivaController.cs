using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSOMA.Domain.Entities;
using SSOMA.Infrastructure.DbContext;

namespace SSOMA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccionesCorrectivaController : ControllerBase
    {
        private readonly SsomaDbContext _context;

        public AccionesCorrectivaController(SsomaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccionesCorrectiva>>> GetAccionesCorrectivas()
        {
            return await _context.AccionesCorrectivas
                .Include(a => a.Reporte)
                .Include(a => a.Responsable)
                .ToListAsync();
        }
    }


}