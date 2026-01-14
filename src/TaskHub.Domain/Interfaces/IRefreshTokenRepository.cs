using TaskHub.Domain.Entities;

namespace TaskHub.Domain.Interfaces;

public interface IRefreshTokenRepository : IGenericRepository<RefreshToken>
{
    Task<RefreshToken?> GetByTokenAsync(string token);
    Task<IEnumerable<RefreshToken>> GetActiveUserTokensAsync(Guid userId);
    Task RevokeAllUserTokensAsync(Guid userId);
    Task<RefreshToken?> GetByIdAsync(Guid userId, Guid tokenId);
}