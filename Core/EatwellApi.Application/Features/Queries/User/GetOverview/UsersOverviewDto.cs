using EatwellApi.Application.Dtos.User;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Features.Queries.User.GetOverview
{
    public class UsersOverviewDto : IDto
    {
        public int TotalUsers { get; set; }

        public int VerifiedUsers { get; set; }

        public int UnverifiedUsers { get; set; }

        public int ThisMonthRegisteredUsers { get; set; }

        public decimal TotalRevenue { get; set; }

        public decimal AverageOrderValue { get; set; }

        public decimal OrderRatio { get; set; }

        public decimal NoOrderRatio { get; set; }

        //public List<MonthlyUserTrendDto> MonthlyUserTrends { get; set; }

        //public List<ActiveUserTrendDto> ActiveUserTrend { get; set; }

        public UserChurnTrendDto UserChurnTrend { get; set; }

        //public List<VipCustomerDto> TopVipCustomers { get; set; }

        public PaginationResponse<UserListDto> Users { get; set; }
    }
}
