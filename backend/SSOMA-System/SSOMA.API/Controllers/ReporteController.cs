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
        public async Task<ActionResult<IEnumerable<Report>>> GetReportes()
        {
            return await _context.Reports
                .Include(r => r.User)
                .Include(r => r.Category)
                .Include(r => r.CorrectiveActions)
                .Include(r => r.Evidences)
                .ToListAsync();
        }
    }

}