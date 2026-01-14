using TaskHub.Domain.Common;
using TaskHub.Domain.Enums;

namespace TaskHub.Domain.Entities;

/// Entity Project - Dự án
public class Project : BaseEntity
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsDelete { get; set; } = false;
    public ProjectStatus Status { get; set; } = ProjectStatus.Todo;

    // Navigation properties
    public User User { get; set; } = null!;
    public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
}