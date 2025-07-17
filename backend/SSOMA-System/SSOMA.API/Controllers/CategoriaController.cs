using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSOMA.Domain.Entities;
using SSOMA.Infrastructure.DbContext;

namespace SSOMA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly SsomaDbContext _context;

        public CategoriaController(SsomaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }
    }

}