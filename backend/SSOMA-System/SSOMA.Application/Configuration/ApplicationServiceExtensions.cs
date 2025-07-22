using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity; // ✅ Asegúrate de tener esto
using SSOMA.Application.Features.Users.Commands.CreateUser;
using SSOMA.Application.Mappings;
using SSOMA.Application.Services;
using SSOMA.Application.Validators.Users;
using SSOMA.Domain.Entities; // Asegúrate de importar correctamente la clase User
using SSOMA.Domain.Services;

namespace SSOMA.Application.Configuration;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        // ✅ MediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly);
        });

        // ✅ Registro del hasher de contraseñas
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

        // ✅ Registro del generador de JWT
        services.AddScoped<IJwtGenerator, JwtGenerator>();
        
        // ✅ FluentValidation
        services.AddValidatorsFromAssemblyContaining<RegisterUserRequestValidator>();
        services.AddFluentValidationAutoValidation(); // Esto habilita la validación automática de modelos


        return services;
    }
}