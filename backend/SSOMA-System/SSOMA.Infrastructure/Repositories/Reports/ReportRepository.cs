using Microsoft.EntityFrameworkCore;
using SSOMA.Domain.Entities;
using SSOMA.Domain.IRepositories.Reports;
using SSOMA.Infrastructure.DbContext;

namespace SSOMA.Infrastructure.Repositories.Reports;

public class ReportRepository : GenericRepository<Report>, IReportRepository
{
    private readonly SsomaDbContext _context;

    public ReportRepository(SsomaDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Report>> GetReportsByUserAsync(int userId)
    {
        return await _context.Reports
            .Where(r => r.UserId == userId)
            .ToListAsync();
    }
    
    public async Task<Report?> GetWithCategoryByIdAsync(int id)
    {
        return await _context.Reports
            .Include(r => r.Category).ThenInclude(c => c.Type)
            .FirstOrDefaultAsync(r => r.Id == id);
    }
}