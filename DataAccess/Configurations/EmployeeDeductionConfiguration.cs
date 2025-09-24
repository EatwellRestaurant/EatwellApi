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
    public class EmployeeDeductionConfiguration : IEntityTypeConfiguration<EmployeeDeduction>
    {
        public void Configure(EntityTypeBuilder<EmployeeDeduction> builder)
        {
            builder.Property(e => e.PaymentStatus).HasDefaultValue(PaymentStatusEnum.Pending);
            
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_EmployeeDeduction_Year", "[Year] >= 1900 AND [Year] <= 2100");
                t.HasCheckConstraint("CK_EmployeeDeduction_Month", "[Month] >= 1 AND [Month] <= 12");
            });


            builder.HasOne(e => e.Employee).WithMany(e => e.EmployeeDeductions).HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
