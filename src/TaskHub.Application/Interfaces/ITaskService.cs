using TaskHub.Application.Common;
using TaskHub.Application.DTOs.Task;

namespace TaskHub.Application.Interfaces;

public interface ITaskService
{
    Task<PaginatedResult<TaskItemDto>> GetTasksAsync(Guid userId, Guid projectId, int? status, int? priority, bool? isCompleted, int page, int limit);
    Task<TaskItemDto> GetTaskByIdAsync(Guid userId, Guid taskId);
    Task<TaskItemDto> CreateTaskAsync(Guid userId, CreateTaskRequestDto request);
    Task<TaskItemDto> UpdateTaskAsync(Guid userId, Guid taskId, UpdateTaskRequestDto request);
    Task<TaskItemDto> UpdateTaskStatusAsync(Guid userId, Guid taskId, UpdateTaskStatusRequestDto request);
    Task DeleteTaskAsync(Guid userId, Guid taskId);
}