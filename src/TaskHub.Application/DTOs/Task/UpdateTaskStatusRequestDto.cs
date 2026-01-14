namespace TaskHub.Application.DTOs.Task;

public class UpdateTaskStatusRequestDto
{
    public bool IsCompleted { get; set; }
    public int Status { get; set; }
}