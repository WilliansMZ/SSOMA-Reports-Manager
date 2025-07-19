// En Api/DependencyInjection/ApiServicesExtensions.cs

using Microsoft.OpenApi.Models;

namespace SSOMA.API.Configuration
{
    public static class ApiServicesExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            // Ejemplo: Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SSOMA API",
                    Version = "v1"
                });
            });

            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            

            // Validaciones (por ejemplo FluentValidation)
            // services.AddValidatorsFromAssemblyContaining<AlgunaClase>();

            // CORS (opcional)
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            return services;
        }
    }
}