namespace EatwellApi.Application.Features.Queries.User.GetOverview
{
    public sealed record UsersOverviewStatistics(
        int TotalUsers,
        int VerifiedUsers,
        int UnverifiedUsers,
        int ThisMonthRegisteredUsers,
        int ActiveUsersCount,
        int AtRiskUsersCount,
        int ChurnedUsersCount
    );

}
