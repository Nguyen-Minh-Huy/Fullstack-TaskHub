using TaskHub.Domain.Common;

namespace TaskHub.Domain.Entities;

/// Entity User - Người dùng hệ thống
public class User : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime? LastLogin { get; set; }

    // Navigation properties
    public ICollection<Project> Projects { get; set; } = new List<Project>();
    public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}