using EatwellApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatwellApi.Persistence.Configurations
{
    public class EmployeeSubTaskConfiguration : IEntityTypeConfiguration<EmployeeSubTask>
    {
        public void Configure(EntityTypeBuilder<EmployeeSubTask> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(250);


            builder.HasOne(e => e.EmployeeTask).WithMany(e => e.EmployeeSubTasks).HasForeignKey(e => e.EmployeeTaskId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
