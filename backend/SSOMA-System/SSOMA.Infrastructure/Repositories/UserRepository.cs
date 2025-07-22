using Microsoft.EntityFrameworkCore;
using SSOMA.Domain.Entities;
using SSOMA.Domain.IRepositories.Users;
using SSOMA.Infrastructure.DbContext;

namespace SSOMA.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly SsomaDbContext _context;

    public UserRepository(SsomaDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .Include(u => u.Role) // 👈 esto es clave
            .FirstOrDefaultAsync(u => u.Email == email);
    }
}