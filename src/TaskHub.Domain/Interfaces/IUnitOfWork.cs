namespace TaskHub.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IProjectRepository Projects { get; }
    ITaskItemRepository TaskItems { get; }
    IRefreshTokenRepository RefreshTokens { get; }
    IBlacklistTokenRepository BlacklistTokens { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}