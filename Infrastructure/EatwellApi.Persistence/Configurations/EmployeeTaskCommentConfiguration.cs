using EatwellApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatwellApi.Persistence.Configurations
{
    public class EmployeeTaskCommentConfiguration : IEntityTypeConfiguration<EmployeeTaskComment>
    {
        public void Configure(EntityTypeBuilder<EmployeeTaskComment> builder)
        {
            builder.Property(e => e.Comment).HasMaxLength(1000);



            builder.HasOne(e => e.Employee).WithMany(e => e.EmployeeTaskComments).HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.EmployeeTask).WithMany(e => e.EmployeeTaskComments).HasForeignKey(e => e.EmployeeTaskId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
