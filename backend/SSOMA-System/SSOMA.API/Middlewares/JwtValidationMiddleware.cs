using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SSOMA.API.Middlewares;

public class JwtValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public JwtValidationMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("Authorization", out var authHeader))
        {
            // No bloquea, deja que JwtBearer haga su trabajo
            await _next(context);
            return;
        }

        var token = authHeader.ToString().Split(" ").LastOrDefault();

        if (string.IsNullOrEmpty(token))
        {
            await RespondWithError(context, 401, "❌ Token JWT no proporcionado.");
            return;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _configuration["Jwt:Issuer"],
            ValidAudience = _configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ClockSkew = TimeSpan.Zero
        };

        try
        {
            var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

            if (validatedToken is not JwtSecurityToken jwtToken ||
                !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                await RespondWithError(context, 401, "❌ Token no válido.");
                return;
            }

            context.User = principal;
            await _next(context); // Continuar
        }
        catch (SecurityTokenExpiredException)
        {
            await RespondWithError(context, 401, "❌ Token expirado.");
        }
        catch (Exception ex)
        {
            await RespondWithError(context, 401, $"❌ Token inválido: {ex.Message}");
        }
    }
    private async Task RespondWithError(HttpContext context, int statusCode, string message)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        var response = new
        {
            error = true,
            statusCode = statusCode,
            message = message
        };

        await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
    }

}
