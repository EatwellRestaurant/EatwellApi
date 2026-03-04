namespace EatwellApi.Application.Features.Queries.Employee.GetOverview
{
    public sealed record EmployeesOverviewStatistics(
        int TotalEmployees,
        int ActiveEmployees,
        int Chefs,
        int Waiters
        );
}
