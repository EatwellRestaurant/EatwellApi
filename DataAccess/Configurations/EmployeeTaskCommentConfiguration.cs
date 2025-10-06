using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
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
