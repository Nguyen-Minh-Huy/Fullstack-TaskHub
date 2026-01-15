using TaskHub.Application.DTOs.Dashboard;

namespace TaskHub.Application.Interfaces;

public interface IDashboardService
{
    Task<DashboardSummaryDto> GetDashboardSummaryAsync(Guid userId);
}