using SSOMA.Domain.Entities;

namespace SSOMA.Domain.IRepositories.Reports
{
    public interface IReportRepository : IGenericRepository<Report>
    {
        // Puedes agregar métodos personalizados si los necesitas, por ejemplo:
        Task<IEnumerable<Report>> GetReportsByUserAsync(int userId);
        Task<Report?> GetWithCategoryByIdAsync(int id);
        Task<List<Report>> GetAllWithCategoryAsync();
        Task<Report?> GetFullReportByIdAsync(int id);
        
        Task<List<Report>> FilterReportsAsync(
            string? status = null,
            string? type = null,
            int? categoryId = null,
            int? userId = null,
            DateOnly? fromDate = null,
            DateOnly? toDate = null,
            int page = 1,
            int pageSize = 10
        );

    }
}