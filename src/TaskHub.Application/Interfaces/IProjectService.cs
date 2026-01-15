using TaskHub.Application.Common;
using TaskHub.Application.DTOs.Project;

namespace TaskHub.Application.Interfaces;

public interface IProjectService
{
    Task<PaginatedResult<ProjectDto>> GetProjectsAsync(Guid userId, string? keyword, int? status, int page, int limit);
    Task<ProjectDto> GetProjectByIdAsync(Guid userId, Guid projectId);
    Task<ProjectDto> CreateProjectAsync(Guid userId, CreateProjectRequestDto request);
    Task<ProjectDto> UpdateProjectAsync(Guid userId, Guid projectId, UpdateProjectRequestDto request);
    Task DeleteProjectAsync(Guid userId, Guid projectId);
    Task<ProjectStatsDto> GetProjectStatsAsync(Guid userId, Guid projectId);
}