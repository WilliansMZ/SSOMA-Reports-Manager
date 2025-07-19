using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSOMA.Domain.Entities;
using SSOMA.Infrastructure.DbContext;

namespace SSOMA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvidenciaController : ControllerBase
    {
        private readonly SsomaDbContext _context;

        public EvidenciaController(SsomaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evidence>>> GetEvidencias()
        {
            return await _context.Evidences
                .Include(e => e.Report)
                .ToListAsync();
        }
    }


}