using TaskHub.Domain.Common;

namespace TaskHub.Domain.Entities;

/// Entity RefreshToken - Token làm mới phiên đăng nhập
public class RefreshToken : BaseEntity
{
    public Guid UserId { get; set; }
    public string Token { get; set; } = string.Empty;
    public string JwtId { get; set; } = string.Empty;
    public bool IsUsed { get; set; } = false;
    public bool IsRevoked { get; set; } = false;
    public DateTime IssuedAt { get; set; }
    public DateTime ExpiredAt { get; set; }

    // Navigation properties
    public User User { get; set; } = null!;
}