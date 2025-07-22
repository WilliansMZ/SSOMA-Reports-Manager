// En Infrastructure/DependencyInjection/InfrastructureServicesExtensions.cs

using Microsoft.Extensions.DependencyInjection;
using SSOMA.Domain.IRepositories;
using SSOMA.Domain.IUnitOfWork;
//using SSOMA.Infrastructure.Repositories;

namespace SSOMA.Infrastructure.Configuration
{
    public static class InfrastructureServicesExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Registra el repositorio genérico
          //  services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Registra el Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            

            return services;
        }
    }
}