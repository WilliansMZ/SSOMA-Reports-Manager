using Microsoft.EntityFrameworkCore;
using SSOMA.Domain.Entities;
using SSOMA.Domain.IRepositories.UserRoles;
using SSOMA.Infrastructure.DbContext;

namespace SSOMA.Infrastructure.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    private readonly SsomaDbContext _context;

    public RoleRepository(SsomaDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Role?> GetByNameAsync(string name)
    {
        return await _context.Roles.FirstOrDefaultAsync(r => r.Name == name);
    }
}