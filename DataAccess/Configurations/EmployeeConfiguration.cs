using Entities.Concrete;
using Entities.Enums.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property(e => e.Address).HasMaxLength(500);
            builder.Property(e => e.Phone).HasMaxLength(14);
            builder.Property(e => e.Gender).HasDefaultValue(GenderType.Male);
            builder.Property(e => e.EducationLevel).HasDefaultValue(EducationLevelType.Bachelor);
            builder.Property(e => e.WorkStatus).HasDefaultValue(WorkStatusType.Active);
            builder.Property(e => e.EmploymentType).HasDefaultValue(EmploymentType.FullTime);


            builder.HasOne(e => e.User).WithOne(u => u.Employee).HasForeignKey<Employee>(e => e.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Branch).WithMany(b => b.Employees).HasForeignKey(e => e.BranchId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.OperationClaim).WithMany(o => o.Employees).HasForeignKey(e => e.OperationClaimId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.City).WithMany(c => c.Employees).HasForeignKey(e => e.CityId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
