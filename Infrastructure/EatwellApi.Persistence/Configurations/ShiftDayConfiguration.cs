using EatwellApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatwellApi.Persistence.Configurations
{
    public class ShiftDayConfiguration : IEntityTypeConfiguration<ShiftDay>
    {
        public void Configure(EntityTypeBuilder<ShiftDay> builder)
        {
            builder.HasKey(s => new { s.ShiftId, s.EmployeeId });
            builder.Property(s => s.IsHoliday).HasDefaultValue(false);
            builder.Property(s => s.IsLeave).HasDefaultValue(false);


            builder.HasOne(s => s.Shift).WithMany(s => s.ShiftDays).HasForeignKey(s => s.ShiftId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Employee).WithMany(e => e.ShiftDays).HasForeignKey(s => s.EmployeeId);
        }
    }
}
