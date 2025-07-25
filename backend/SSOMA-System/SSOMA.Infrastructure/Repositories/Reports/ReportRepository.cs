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
    
    public async Task<List<Report>> GetAllWithCategoryAsync()
    {
        return await _context.Reports
            .Include(r => r.Category).ThenInclude(c => c.Type)
            .ToListAsync();
    }
    
    public async Task<Report?> GetFullReportByIdAsync(int id)
    {
        return await _context.Reports
            .Include(r => r.User)
            .Include(r => r.Category)
            .ThenInclude(c => c.Type)
            .Include(r => r.Evidences)
            .Include(r => r.CorrectiveActions)
            .ThenInclude(ca => ca.Responsible)
            .FirstOrDefaultAsync(r => r.Id == id);
    }
    
    public async Task<List<Report>> FilterReportsAsync(
        string? status = null,
        string? type = null,
        int? categoryId = null,
        int? userId = null,
        DateOnly? fromDate = null,
        DateOnly? toDate = null,
        int page = 1,
        int pageSize = 10)
    {
        var query = _context.Reports
            .Include(r => r.Category)
            .ThenInclude(c => c.Type)
            .Include(r => r.User)
            .AsQueryable();
        if (!string.IsNullOrEmpty(status))
            query = query.Where(r => r.Status == status);

        if (!string.IsNullOrEmpty(type))
            query = query.Where(r => r.Category.Type.Name == type);

        if (categoryId.HasValue)
            query = query.Where(r => r.CategoryId == categoryId);

        if (userId.HasValue)
            query = query.Where(r => r.UserId == userId);

        if (fromDate.HasValue)
            query = query.Where(r => r.ReportDate >= fromDate.Value);

        if (toDate.HasValue)
            query = query.Where(r => r.ReportDate <= toDate.Value);

        // Paginación
        query = query
            .OrderByDescending(r => r.ReportDate) // o por otro campo
            .Skip((page - 1) * pageSize)
            .Take(pageSize);

        return await query.ToListAsync();
    }
}