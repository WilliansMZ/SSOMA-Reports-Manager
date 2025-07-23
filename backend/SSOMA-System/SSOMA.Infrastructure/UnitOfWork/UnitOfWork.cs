
using SSOMA.Domain.Entities;
using SSOMA.Domain.IRepositories;
using SSOMA.Domain.IRepositories.UserRoles;
using SSOMA.Domain.IRepositories.Users;
using SSOMA.Domain.IUnitOfWork;
using SSOMA.Infrastructure.DbContext;
using SSOMA.Infrastructure.Repositories;


namespace SSOMA.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly SsomaDbContext _context;

    public IGenericRepository<User> Usuarios { get; }
    public IGenericRepository<Report> Reportes { get; }
    public IGenericRepository<Category> Categorias { get; }
    public IGenericRepository<Evidence> Evidencias { get; }
    public IGenericRepository<CorrectiveAction> AccionesCorrectivas { get; }
    
    public IGenericRepository<Role> Roles { get; }
    
    
    //Repositorios Especificos
    private IUserRepository? _users;
    public IUserRepository UserRepository => _users ??= new UserRepository(_context); // Repositorio personalizado
    public IRoleRepository RoleRepository => new RoleRepository(_context);

    public UnitOfWork(SsomaDbContext context)
    {
        _context = context;
        Usuarios = new GenericRepository<User>(_context);
        Reportes = new GenericRepository<Report>(_context);
        Categorias = new GenericRepository<Category>(_context);
        Evidencias = new GenericRepository<Evidence>(_context);
        AccionesCorrectivas = new GenericRepository<CorrectiveAction>(_context);
        Roles = new GenericRepository<Role>(_context);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}