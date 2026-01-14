namespace TaskHub.Application.DTOs.Project;

public class UpdateProjectRequestDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? Status { get; set; }
}