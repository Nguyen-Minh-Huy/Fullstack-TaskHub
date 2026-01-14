using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskHub.Domain.Entities;

namespace TaskHub.Infrastructure.Data.Configurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("refresh_tokens");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasColumnName("id")
            .HasDefaultValueSql("NEWID()");

        builder.Property(r => r.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(r => r.Token)
            .HasColumnName("token")
            .HasColumnType("varchar(1000)")
            .IsRequired();

        builder.Property(r => r.JwtId)
            .HasColumnName("jwt_id")
            .HasColumnType("varchar(36)")
            .IsRequired();

        builder.Property(r => r.IsUsed)
            .HasColumnName("is_used")
            .HasDefaultValue(false);

        builder.Property(r => r.IsRevoked)
            .HasColumnName("is_revoked")
            .HasDefaultValue(false);

        builder.Property(r => r.IssuedAt)
            .HasColumnName("issued_at")
            .HasDefaultValueSql("GETDATE()");

        builder.Property(r => r.ExpiredAt)
            .HasColumnName("expired_at")
            .IsRequired();

        builder.Property(r => r.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("GETDATE()");

        builder.Property(r => r.UpdateAt)
            .HasColumnName("update_at")
            .HasDefaultValueSql("GETDATE()");

        // Indexes
        builder.HasIndex(r => r.Token)
            .HasDatabaseName("IX_RefreshTokens_Token");

        builder.HasIndex(r => r.UserId)
            .HasDatabaseName("IX_RefreshTokens_UserId");
    }
}