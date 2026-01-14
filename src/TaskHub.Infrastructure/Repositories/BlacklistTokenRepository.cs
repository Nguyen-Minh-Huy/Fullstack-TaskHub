using Microsoft.EntityFrameworkCore;
using TaskHub.Domain.Entities;
using TaskHub.Domain.Interfaces;
using TaskHub.Infrastructure.Data;

namespace TaskHub.Infrastructure.Repositories;

public class BlacklistTokenRepository : GenericRepository<BlacklistToken>, IBlacklistTokenRepository
{
    public BlacklistTokenRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<bool> IsTokenBlacklistedAsync(string jti)
    {
        return await _dbSet
            .AnyAsync(bt => bt.Jti == jti);
    }

    public async Task BlacklistTokenAsync(string jti, DateTime expiredAt)
    {
        var blacklistToken = new BlacklistToken
        {
            Jti = jti,
            ExpiredAt = expiredAt
        };

        await AddAsync(blacklistToken);
    }

    public async Task CleanupExpiredTokensAsync()
    {
        var now = DateTime.UtcNow;
        var expiredTokens = await _dbSet
            .Where(bt => bt.ExpiredAt < now)
            .ToListAsync();

        RemoveRange(expiredTokens);
    }
}