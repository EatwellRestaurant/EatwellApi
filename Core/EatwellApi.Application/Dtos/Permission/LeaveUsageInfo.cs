using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.Permission
{
    public class LeaveUsageInfo : IDto
    {
        public double UsedLeaveDays { get; set; }
        
        public int ExperienceInYears { get; set; }
    }
}
