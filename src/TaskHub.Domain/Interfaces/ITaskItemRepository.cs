using TaskHub.Domain.Entities;
using TaskHub.Domain.Enums;

namespace TaskHub.Domain.Interfaces;

public interface ITaskItemRepository : IGenericRepository<TaskItem>
{
    Task<IEnumerable<TaskItem>> GetProjectTasksAsync(Guid projectId, bool includeDeleted = false);
    Task<TaskItem?> GetUserTaskByIdAsync(Guid userId, Guid taskId);
    Task<IEnumerable<TaskItem>> GetUserTasksAsync(Guid userId, Guid? projectId, ProjectStatus? status, TaskPriority? priority, bool? isCompleted);
    Task<int> CountTasksByStatusAsync(Guid projectId, ProjectStatus status);
    Task<int> CountOverdueTasksAsync(Guid userId);
}