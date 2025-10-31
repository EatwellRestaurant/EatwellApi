using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.Dashboard
{
    public class DashboardStatisticsDto : IDto
    {
        public int UserCount { get; set; }
        public int MealCategoryCount { get; set; }
        public int OrderCount { get; set; }
        public int ReservationCount { get; set; }
    }
}
