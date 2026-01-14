using Microsoft.EntityFrameworkCore;
using TaskHub.Domain.Entities;
using TaskHub.Domain.Enums;
using TaskHub.Domain.Interfaces;
using TaskHub.Infrastructure.Data;

namespace TaskHub.Infrastructure.Repositories;

public class ProjectRepository : GenericRepository<Project>, IProjectRepository
{
    public ProjectRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Project>> GetUserProjectsAsync(Guid userId, bool includeDeleted = false)
    {
        var query = _dbSet.Where(p => p.UserId == userId);

        if (!includeDeleted)
        {
            query = query.Where(p => !p.IsDelete);
        }

        return await query
            .OrderByDescending(p => p.UpdateAt)
            .ToListAsync();
    }

    public async Task<Project?> GetUserProjectByIdAsync(Guid userId, Guid projectId)
    {
        return await _dbSet
            .FirstOrDefaultAsync(p => p.Id == projectId && p.UserId == userId && !p.IsDelete);
    }

    public async Task<IEnumerable<Project>> SearchUserProjectsAsync(
        Guid userId,
        string? keyword,
        ProjectStatus? status)
    {
        var query = _dbSet
            .Where(p => p.UserId == userId && !p.IsDelete);

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            query = query.Where(p => p.Name.Contains(keyword));
        }

        if (status.HasValue)
        {
            query = query.Where(p => p.Status == status.Value);
        }

        return await query
            .OrderByDescending(p => p.UpdateAt)
            .ToListAsync();
    }
}