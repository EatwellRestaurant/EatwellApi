using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class EmployeeSalaryConfiguration : IEntityTypeConfiguration<EmployeeSalary>
    {
        public void Configure(EntityTypeBuilder<EmployeeSalary> builder)
        {

            builder.HasOne(e => e.Employee).WithMany(e => e.EmployeeSalaries).HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Month).WithMany(m => m.EmployeeSalaries).HasForeignKey(e => e.MonthId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
