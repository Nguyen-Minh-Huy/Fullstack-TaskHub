using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskHub.Domain.Entities;

namespace TaskHub.Infrastructure.Data.Configurations;

public class BlacklistTokenConfiguration : IEntityTypeConfiguration<BlacklistToken>
{
    public void Configure(EntityTypeBuilder<BlacklistToken> builder)
    {
        builder.ToTable("blacklist_token");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasColumnName("id")
            .HasDefaultValueSql("NEWID()");

        builder.Property(b => b.Jti)
            .HasColumnName("jti")
            .HasColumnType("varchar(36)")
            .IsRequired();

        builder.Property(b => b.ExpiredAt)
            .HasColumnName("expired_at")
            .IsRequired();

        // Indexes
        builder.HasIndex(b => b.Jti)
            .HasDatabaseName("IX_Blacklist_JTI");

        builder.HasIndex(b => b.ExpiredAt)
            .HasDatabaseName("IX_Blacklist_ExpiredAt");
    }
}