using EatwellApi.Domain.Entities;
using EatwellApi.Domain.Enums.EmployeeTask;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatwellApi.Persistence.Configurations
{
    public class EmployeeTaskConfiguration : IEntityTypeConfiguration<EmployeeTask>
    {
        public void Configure(EntityTypeBuilder<EmployeeTask> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(250);
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.PriorityLevel).HasDefaultValue(PriorityLevelEnum.Low);
            builder.Property(e => e.TaskStatus).HasDefaultValue(TaskStatusEnum.Pending);



            builder.HasOne(e => e.Assignee).WithMany(e => e.AssignedTasks).HasForeignKey(e => e.AssigneeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.AssignedBy).WithMany(e => e.CreatedTasks).HasForeignKey(e => e.AssignedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
