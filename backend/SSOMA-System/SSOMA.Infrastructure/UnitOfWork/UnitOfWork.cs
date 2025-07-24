using SSOMA.Domain.Entities;
using SSOMA.Domain.IRepositories;
using SSOMA.Domain.IRepositories.Reports;
using SSOMA.Domain.IRepositories.UserRoles;
using SSOMA.Domain.IRepositories.Users;
using SSOMA.Domain.IUnitOfWork;
using SSOMA.Infrastructure.DbContext;
using SSOMA.Infrastructure.Repositories;
using SSOMA.Infrastructure.Repositories.Reports;


namespace SSOMA.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SsomaDbContext _context;

    // Genéricos
    public IGenericRepository<User> Usuarios { get; }
    public IGenericRepository<Report> Reportes { get; }
    public IGenericRepository<Category> Categorias { get; }
    public IGenericRepository<Evidence> Evidencias { get; }
    public IGenericRepository<CorrectiveAction> AccionesCorrectivas { get; }
    public IGenericRepository<Role> Roles { get; }

    // Específicos
    private IUserRepository? _userRepository;
    private IRoleRepository? _roleRepository;
    private IReportRepository? _reportRepository;

    public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
    public IRoleRepository RoleRepository => _roleRepository ??= new RoleRepository(_context);
    public IReportRepository ReportRepository => _reportRepository ??= new ReportRepository(_context);

    public UnitOfWork(SsomaDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));

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
        GC.SuppressFinalize(this);
    }
}
