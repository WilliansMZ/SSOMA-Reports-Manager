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
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (string.IsNullOrWhiteSpace(token))
        {
            await RespondWithError(context, 401, "❌ Token requerido.");
            return;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);

        try
        {
            var parameters = new TokenValidationParameters
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

            var principal = tokenHandler.ValidateToken(token, parameters, out SecurityToken validatedToken);

            var roleClaim = principal.Claims.FirstOrDefault(c =>
                c.Type == "role" || c.Type == ClaimTypes.Role || c.Type.Contains("claims/role"));

            if (roleClaim == null || string.IsNullOrEmpty(roleClaim.Value))
            {
                await RespondWithError(context, 403, "❌ Rol no válido o no presente en el token.");
                return;
            }

            context.User = principal;

            await _next(context);
        }
        catch (SecurityTokenExpiredException)
        {
            await RespondWithError(context, 401, "❌ Token expirado.");
        }
        catch (Exception)
        {
            await RespondWithError(context, 401, "❌ Token inválido.");
        }
    }

    private static async Task RespondWithError(HttpContext context, int statusCode, string message)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync($"{{\"error\": \"{message}\"}}");
    }
}
