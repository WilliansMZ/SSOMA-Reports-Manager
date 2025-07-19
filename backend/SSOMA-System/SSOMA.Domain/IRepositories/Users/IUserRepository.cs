using SSOMA.Domain.Entities;

namespace SSOMA.Domain.IRepositories.Users;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}