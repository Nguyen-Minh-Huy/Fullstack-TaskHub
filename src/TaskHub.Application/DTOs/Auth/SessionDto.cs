namespace TaskHub.Application.DTOs.Auth;

public class SessionDto
{
    public Guid Id { get; set; }
    public DateTime IssuedAt { get; set; }
    public DateTime ExpiredAt { get; set; }
    public bool IsCurrent { get; set; }
}