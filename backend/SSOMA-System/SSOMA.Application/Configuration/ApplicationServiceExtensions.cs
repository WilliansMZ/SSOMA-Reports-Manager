using Microsoft.Extensions.DependencyInjection;
using SSOMA.Application.Features.Users.Commands.CreateUser;
using SSOMA.Application.Mappings;

namespace SSOMA.Application.Configuration;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile).Assembly);
        
        // ✅ MediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly); // Cambia por cualquier clase de Application
        });
        return services;
    }
}