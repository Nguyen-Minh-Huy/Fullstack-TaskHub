namespace TaskHub.Application.DTOs.Task;

public class UpdateTaskRequestDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public int? TaskPriority { get; set; }
    public int? Status { get; set; }
}