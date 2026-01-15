using TaskHub.Application.DTOs.Auth;

namespace TaskHub.Application.Interfaces;

public interface IAuthService
{
    Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto request);
    Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    Task<RefreshTokenResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request);
    Task LogoutAsync(string accessToken);
    Task LogoutAllAsync(Guid userId, string accessToken);
    Task<UserProfileDto> GetProfileAsync(Guid userId);
    Task<List<SessionDto>> GetSessionsAsync(Guid userId, string currentToken);
    Task RevokeSessionAsync(Guid userId, Guid sessionId);
}