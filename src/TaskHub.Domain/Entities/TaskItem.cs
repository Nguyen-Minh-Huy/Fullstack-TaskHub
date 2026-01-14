using TaskHub.Domain.Common;
using TaskHub.Domain.Enums;

namespace TaskHub.Domain.Entities;

/// Entity TaskItem - Công việc
public class TaskItem : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public TaskPriority TaskPriority { get; set; } = TaskPriority.Low;
    public bool IsCompleted { get; set; } = false;
    public bool IsDelete { get; set; } = false;
    public ProjectStatus Status { get; set; } = ProjectStatus.Todo;

    // Navigation properties
    public User User { get; set; } = null!;
    public Project Project { get; set; } = null!;
}