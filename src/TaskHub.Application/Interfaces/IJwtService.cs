using System.Security.Claims;
using TaskHub.Domain.Entities;

namespace TaskHub.Application.Interfaces;

public interface IJwtService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
    ClaimsPrincipal? ValidateToken(string token);
    string? GetJtiFromToken(string token);
    Guid? GetUserIdFromToken(string token);
}