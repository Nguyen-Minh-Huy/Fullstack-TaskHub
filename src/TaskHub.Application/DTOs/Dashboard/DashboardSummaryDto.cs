namespace TaskHub.Application.DTOs.Dashboard;

public class DashboardSummaryDto
{
    public int TotalProjects { get; set; }
    public int ActiveProjects { get; set; }
    public int TotalTasks { get; set; }
    public int CompletedTasks { get; set; }
    public int PendingTasks { get; set; }
    public int OverdueTasks { get; set; }
    public int TasksDueToday { get; set; }
    public int TasksDueThisWeek { get; set; }
    public double CompletionRate { get; set; }
    public Dictionary<string, int> TasksByPriority { get; set; } = new();
    public List<RecentActivityDto> RecentActivities { get; set; } = new();
}

public class RecentActivityDto
{
    public string Type { get; set; } = string.Empty;
    public string TaskTitle { get; set; } = string.Empty;
    public string ProjectName { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}