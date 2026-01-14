using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskHub.Domain.Entities;

namespace TaskHub.Infrastructure.Data.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("projects");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasDefaultValueSql("NEWID()");

        builder.Property(p => p.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(200)")
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnName("description")
            .HasColumnType("varchar(500)");

        builder.Property(p => p.IsDelete)
            .HasColumnName("IsDelete")
            .HasDefaultValue(false);

        builder.Property(p => p.Status)
            .HasColumnName("status")
            .HasColumnType("tinyint")
            .HasDefaultValue(0);

        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("GETDATE()");

        builder.Property(p => p.UpdateAt)
            .HasColumnName("update_at")
            .HasDefaultValueSql("GETDATE()");

        // Indexes
        builder.HasIndex(p => new { p.UserId, p.IsDelete })
            .HasDatabaseName("IX_Projects_UserId_IsDelete");

        // Relationships
        builder.HasMany(p => p.TaskItems)
            .WithOne(t => t.Project)
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}