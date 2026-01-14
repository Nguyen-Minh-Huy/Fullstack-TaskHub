using TaskHub.Domain.Entities;

namespace TaskHub.Domain.Interfaces;

public interface IBlacklistTokenRepository : IGenericRepository<BlacklistToken>
{
    Task<bool> IsTokenBlacklistedAsync(string jti);
    Task BlacklistTokenAsync(string jti, DateTime expiredAt);
    Task CleanupExpiredTokensAsync();
}