using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.HeadOffice
{
    public class HeadOfficeDto : IDto
    {
        public string Address { get; set; }

        public string Phone { get; set; }
        
        public string Email { get; set; }
        
        public string MidWeekWorkingHours { get; set; }
        
        public string WeekendWorkingHours { get; set; }
        
        public string? SpecialNote { get; set; }
        
        public string? Facebook { get; set; }
        
        public string? Instagram { get; set; }
        
        public string? Twitter { get; set; }
        
        public string? Gmail { get; set; }
    }
}
