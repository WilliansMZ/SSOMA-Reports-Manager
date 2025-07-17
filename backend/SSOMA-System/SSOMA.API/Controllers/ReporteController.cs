using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSOMA.Domain.Entities;
using SSOMA.Infrastructure.DbContext;

namespace SSOMA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReporteController : ControllerBase
    {
        private readonly SsomaDbContext _context;

        public ReporteController(SsomaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reporte>>> GetReportes()
        {
            return await _context.Reportes
                .Include(r => r.Usuario)
                .Include(r => r.Categoria)
                .Include(r => r.AccionesCorrectivas)
                .Include(r => r.Evidencia)
                .ToListAsync();
        }
    }

}