using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Features.Queries.User.GetOverview
{
    public class UserChurnTrendDto : IDto
    {
        public int ActiveUsersCount { get; set; }

        public int AtRiskUsersCount { get; set; }

        public int ChurnedUsersCount { get; set; }

    }
}
