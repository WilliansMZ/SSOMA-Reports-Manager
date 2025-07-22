using SSOMA.Domain.Entities;

namespace SSOMA.Domain.Services;

public interface IJwtGenerator
{
    string GenerateToken(User user);
}