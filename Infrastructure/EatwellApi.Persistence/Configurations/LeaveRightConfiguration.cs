using EatwellApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatwellApi.Persistence.Configurations
{
    public class LeaveRightConfiguration : IEntityTypeConfiguration<LeaveRight>
    {
        public void Configure(EntityTypeBuilder<LeaveRight> builder)
        {
            builder.Property(l => l.SeniorityRange).HasMaxLength(10);

            builder.HasData(
                new LeaveRight() { Id = 1, YearId = 1, LeaveTypeId = 1, SeniorityRange = "0-1", DayCount = 14 },
                new LeaveRight() { Id = 2, YearId = 1, LeaveTypeId = 1, SeniorityRange = "5-15", DayCount = 20 },
                new LeaveRight() { Id = 3, YearId = 1, LeaveTypeId = 1, SeniorityRange = "15", DayCount = 26 },
                new LeaveRight() { Id = 4, YearId = 1, LeaveTypeId = 2, SeniorityRange = "*", DayCount = 5 },
                new LeaveRight() { Id = 5, YearId = 1, LeaveTypeId = 3, SeniorityRange = "*", DayCount = 30 },
                new LeaveRight() { Id = 6, YearId = 1, LeaveTypeId = 4, SeniorityRange = "*", DayCount = 10 },
                new LeaveRight() { Id = 7, YearId = 1, LeaveTypeId = 5, SeniorityRange = "*", DayCount = 112 },
                new LeaveRight() { Id = 8, YearId = 1, LeaveTypeId = 6, SeniorityRange = "*", DayCount = 5 },
                new LeaveRight() { Id = 9, YearId = 1, LeaveTypeId = 7, SeniorityRange = "*", DayCount = 3 },
                new LeaveRight() { Id = 10, YearId = 1, LeaveTypeId = 8, SeniorityRange = "*", DayCount = 5 });
        }
    }
}
