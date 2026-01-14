namespace TaskHub.Domain.Entities;

/// Entity BlacklistToken - Token bị vô hiệu hóa
public class BlacklistToken
{
    public Guid Id { get; set; }
    public string Jti { get; set; } = string.Empty;
    public DateTime ExpiredAt { get; set; }

    public BlacklistToken()
    {
        Id = Guid.NewGuid();
    }
}