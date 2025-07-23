using SSOMA.Domain.Entities;

namespace SSOMA.Domain.IRepositories.UserRoles;

public interface IRoleRepository : IGenericRepository<Role>
{
    Task<Role?> GetByNameAsync(string name);
}