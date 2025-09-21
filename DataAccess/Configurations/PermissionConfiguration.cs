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
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.Property(p => p.Description).HasMaxLength(500);


            builder.HasOne(p => p.Employee).WithMany(e => e.Permissions).HasForeignKey(p => p.EmployeeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Year).WithMany(y => y.Permissions).HasForeignKey(p => p.YearId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.LeaveType).WithMany(l => l.Permissions).HasForeignKey(p => p.LeaveTypeId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
