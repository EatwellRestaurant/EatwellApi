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
    public class EmployeeSubTaskConfiguration : IEntityTypeConfiguration<EmployeeSubTask>
    {
        public void Configure(EntityTypeBuilder<EmployeeSubTask> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(250);


            builder.HasOne(e => e.EmployeeTask).WithMany(e => e.EmployeeSubTasks).HasForeignKey(e => e.EmployeeTaskId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
