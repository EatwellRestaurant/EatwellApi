using Entities.Concrete;
using Entities.Enums.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class EmployeeBonusConfiguration : IEntityTypeConfiguration<EmployeeBonus>
    {
        public void Configure(EntityTypeBuilder<EmployeeBonus> builder)
        {
            builder.Property(e => e.BonusType).HasDefaultValue(BonusType.Special);
            builder.Property(e => e.PaymentStatus).HasDefaultValue(PaymentStatusEnum.Pending);
            

            builder.HasOne(e => e.Employee).WithMany(e => e.EmployeeBonuses).HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Month).WithMany(m => m.EmployeeBonuses).HasForeignKey(e => e.MonthId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
