using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSOMA.Domain.Entities;
using SSOMA.Infrastructure.DbContext;

namespace SSOMA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CorrectiveActionsController : ControllerBase
    {
        private readonly SsomaDbContext _context;

        public CorrectiveActionsController(SsomaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CorrectiveAction>>> GetCorrectiveActions()
        {
            return await _context.CorrectiveActions
                .Include(a => a.Report)
                .Include(a => a.Responsible)
                .ToListAsync();
        }
    }
}