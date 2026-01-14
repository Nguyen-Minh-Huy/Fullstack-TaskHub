using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskHub.Domain.Entities;

namespace TaskHub.Infrastructure.Data.Configurations;

public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.ToTable("taskitems");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .HasColumnName("id")
            .HasDefaultValueSql("NEWID()");

        builder.Property(t => t.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(t => t.ProjectId)
            .HasColumnName("project_id")
            .IsRequired();

        builder.Property(t => t.Title)
            .HasColumnName("title")
            .HasColumnType("varchar(150)")
            .IsRequired();

        builder.Property(t => t.Description)
            .HasColumnName("description")
            .HasColumnType("varchar(500)");

        builder.Property(t => t.DueDate)
            .HasColumnName("due_date")
            .HasColumnType("date");

        builder.Property(t => t.TaskPriority)
            .HasColumnName("task_priority")
            .HasColumnType("tinyint");

        builder.Property(t => t.IsCompleted)
            .HasColumnName("IsCompleted")
            .HasDefaultValue(false);

        builder.Property(t => t.IsDelete)
            .HasColumnName("IsDelete")
            .HasDefaultValue(false);

        builder.Property(t => t.Status)
            .HasColumnName("status")
            .HasColumnType("tinyint")
            .HasDefaultValue(0);

        builder.Property(t => t.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("GETDATE()");

        builder.Property(t => t.UpdateAt)
            .HasColumnName("update_at")
            .HasDefaultValueSql("GETDATE()");

        // Indexes
        builder.HasIndex(t => new { t.ProjectId, t.IsDelete })
            .HasDatabaseName("IX_Tasks_ProjectId_IsDelete");

        builder.HasIndex(t => new { t.UserId, t.Status, t.IsDelete })
            .HasDatabaseName("IX_Tasks_UserId_Status");
    }
}