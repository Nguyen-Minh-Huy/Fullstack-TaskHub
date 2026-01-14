using TaskHub.Domain.Entities;
using TaskHub.Domain.Enums;

namespace TaskHub.Domain.Interfaces;

public interface IProjectRepository : IGenericRepository<Project>
{
    Task<IEnumerable<Project>> GetUserProjectsAsync(Guid userId, bool includeDeleted = false);
    Task<Project?> GetUserProjectByIdAsync(Guid userId, Guid projectId);
    Task<IEnumerable<Project>> SearchUserProjectsAsync(Guid userId, string? keyword, ProjectStatus? status);
}