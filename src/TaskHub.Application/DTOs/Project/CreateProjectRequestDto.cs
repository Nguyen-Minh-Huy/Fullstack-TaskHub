namespace TaskHub.Application.DTOs.Project;

public class CreateProjectRequestDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}