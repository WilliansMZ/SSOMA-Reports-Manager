using SSOMA.Domain.Entities;
using SSOMA.Domain.IRepositories;
using SSOMA.Domain.IRepositories.UserRoles;
using SSOMA.Domain.IRepositories.Users;

namespace SSOMA.Domain.IUnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<User> Usuarios { get; }
    IGenericRepository<Report> Reportes { get; }
    IGenericRepository<Category> Categorias { get; }
    IGenericRepository<Evidence> Evidencias { get; }
    IGenericRepository<Role> Roles { get; }
    IGenericRepository<CorrectiveAction> AccionesCorrectivas { get; }
    
    //repositorios especificos
    IUserRepository UserRepository { get; }
    IRoleRepository RoleRepository { get; }
    Task<int> SaveAsync();
}