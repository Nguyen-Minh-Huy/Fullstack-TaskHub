namespace TaskHub.Domain.Common;

/// Base entity cho tất cả các entities
public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdateAt = DateTime.UtcNow;
    }
}