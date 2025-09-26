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
            

            builder.HasOne(e => e.Employee).WithMany(e => e.EmployeeDeductions).HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Month).WithMany(m => m.EmployeeDeductions).HasForeignKey(e => e.MonthId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
