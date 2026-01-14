using Microsoft.EntityFrameworkCore;
using TaskHub.Domain.Entities;
using TaskHub.Domain.Enums;
using TaskHub.Domain.Interfaces;
using TaskHub.Infrastructure.Data;

namespace TaskHub.Infrastructure.Repositories;

public class TaskItemRepository : GenericRepository<TaskItem>, ITaskItemRepository
{
    public TaskItemRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TaskItem>> GetProjectTasksAsync(Guid projectId, bool includeDeleted = false)
    {
        var query = _dbSet.Where(t => t.ProjectId == projectId);

        if (!includeDeleted)
        {
            query = query.Where(t => !t.IsDelete);
        }

        return await query
            .OrderByDescending(t => t.UpdateAt)
            .ToListAsync();
    }

    public async Task<TaskItem?> GetUserTaskByIdAsync(Guid userId, Guid taskId)
    {
        return await _dbSet
            .FirstOrDefaultAsync(t => t.Id == taskId && t.UserId == userId && !t.IsDelete);
    }

    public async Task<IEnumerable<TaskItem>> GetUserTasksAsync(
        Guid userId,
        Guid? projectId,
        ProjectStatus? status,
        TaskPriority? priority,
        bool? isCompleted)
    {
        var query = _dbSet.Where(t => t.UserId == userId && !t.IsDelete);

        if (projectId.HasValue)
        {
            query = query.Where(t => t.ProjectId == projectId.Value);
        }

        if (status.HasValue)
        {
            query = query.Where(t => t.Status == status.Value);
        }

        if (priority.HasValue)
        {
            query = query.Where(t => t.TaskPriority == priority.Value);
        }

        if (isCompleted.HasValue)
        {
            query = query.Where(t => t.IsCompleted == isCompleted.Value);
        }

        return await query
            .OrderByDescending(t => t.UpdateAt)
            .ToListAsync();
    }

    public async Task<int> CountTasksByStatusAsync(Guid projectId, ProjectStatus status)
    {
        return await _dbSet
            .CountAsync(t => t.ProjectId == projectId && t.Status == status && !t.IsDelete);
    }

    public async Task<int> CountOverdueTasksAsync(Guid userId)
    {
        var today = DateTime.UtcNow.Date;
        return await _dbSet
            .CountAsync(t => t.UserId == userId
                && !t.IsCompleted
                && !t.IsDelete
                && t.DueDate.HasValue
                && t.DueDate.Value < today);
    }
}