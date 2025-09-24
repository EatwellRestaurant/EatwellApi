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
            
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_EmployeeBonus_Year", "[Year] >= 1900 AND [Year] <= 2100");
                t.HasCheckConstraint("CK_EmployeeBonus_Month", "[Month] >= 1 AND [Month] <= 12");
            });


            builder.HasOne(e => e.Employee).WithMany(e => e.EmployeeBonuses).HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
