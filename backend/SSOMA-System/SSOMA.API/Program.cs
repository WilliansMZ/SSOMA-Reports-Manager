using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SSOMA.API.Configuration;
using SSOMA.Application.Configuration;
using SSOMA.Infrastructure.Configuration;
using SSOMA.Infrastructure.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
builder.Services.AddControllers(); // Habilita los controladores
builder.Services.AddEndpointsApiExplorer(); // Necesario para Swagger
builder.Services.AddSwaggerGen(); // Habilita Swagger UI

// Agrega servicios de infraestructura
builder.Services.AddInfrastructure();
// Servicios API
builder.Services.AddApiServices();
//Servicios Application
builder.Services.AddApplicationServices();


// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve); // 🚀 Esta línea evita el ciclo


// Configurar la cadena de conexión a PostgreSQL
builder.Services.AddDbContext<SsomaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configurar el middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapear los controladores
app.MapControllers();

app.Run();