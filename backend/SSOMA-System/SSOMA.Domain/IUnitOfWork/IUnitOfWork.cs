using SSOMA.Domain.Entities;
using SSOMA.Domain.IRepositories;
using SSOMA.Domain.IRepositories.Users;

namespace SSOMA.Domain.IUnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<User> Usuarios { get; }
    IGenericRepository<Report> Reportes { get; }
    IGenericRepository<Category> Categorias { get; }
    IGenericRepository<Evidence> Evidencias { get; }
    IGenericRepository<CorrectiveAction> AccionesCorrectivas { get; }
    
    //repositorios especificos
    IUserRepository UserRepository { get; }

    Task<int> SaveAsync();
}