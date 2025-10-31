using EatwellApi.Domain.Entities;
using EatwellApi.Domain.Enums.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatwellApi.Persistence.Configurations
{
    public class EmployeeSalaryConfiguration : IEntityTypeConfiguration<EmployeeSalary>
    {
        public void Configure(EntityTypeBuilder<EmployeeSalary> builder)
        {
            builder.Property(e => e.PaymentStatus).HasDefaultValue(PaymentStatusEnum.Pending);

            builder.HasOne(e => e.Employee).WithMany(e => e.EmployeeSalaries).HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Month).WithMany(m => m.EmployeeSalaries).HasForeignKey(e => e.MonthId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
