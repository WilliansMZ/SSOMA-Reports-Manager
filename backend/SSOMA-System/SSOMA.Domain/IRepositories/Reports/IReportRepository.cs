using SSOMA.Domain.Entities;

namespace SSOMA.Domain.IRepositories.Reports
{
    public interface IReportRepository : IGenericRepository<Report>
    {
        // Puedes agregar métodos personalizados si los necesitas, por ejemplo:
        Task<IEnumerable<Report>> GetReportsByUserAsync(int userId);
        Task<Report?> GetWithCategoryByIdAsync(int id);
    }
}