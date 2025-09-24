using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class EmployeeSalaryConfiguration : IEntityTypeConfiguration<EmployeeSalary>
    {
        public void Configure(EntityTypeBuilder<EmployeeSalary> builder)
        {
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_EmployeeSalary_Year", "[Year] >= 1900 AND [Year] <= 2100");
                t.HasCheckConstraint("CK_EmployeeSalary_Month", "[Month] >= 1 AND [Month] <= 12");
            });


            builder.HasOne(e => e.Employee).WithMany(e => e.EmployeeSalaries).HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
