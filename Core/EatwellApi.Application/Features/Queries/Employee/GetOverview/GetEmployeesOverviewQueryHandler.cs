using EatwellApi.Application.Abstractions.Repositories.Employee;
using EatwellApi.Application.Constants.Messages;
using EatwellApi.Application.Dtos.Employee;
using EatwellApi.Application.Extensions;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.Employee;
using EatwellApi.Domain.Enums.OperationClaim;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DomainEmployee = EatwellApi.Domain.Entities.Employee;

namespace EatwellApi.Application.Features.Queries.Employee.GetOverview
{
    public class GetEmployeesOverviewQueryHandler(IEmployeeReadRepository readRepository) : IRequestHandler<GetEmployeesOverviewQueryRequest, DataResponse<EmployeesOverviewDto>>
    {
        readonly IEmployeeReadRepository _readRepository = readRepository;



        public async Task<DataResponse<EmployeesOverviewDto>> Handle(GetEmployeesOverviewQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<DomainEmployee> query = _readRepository
                .Where(e => !e.User.IsDeleted)
                .AsNoTracking();


            EmployeesOverviewStatistics statistics = await query
            .GroupBy(_ => 1)
            .Select(g => new EmployeesOverviewStatistics(
                g.Count(),
                g.Count(e => e.WorkStatus == WorkStatusType.Active),
                g.Count(e => e.User.OperationClaimId == (int)OperationClaimEnum.Chef),
                g.Count(e => e.User.OperationClaimId == (int)OperationClaimEnum.Waiter)
            ))
            .SingleAsync(cancellationToken);


            List<EmployeeListDto> employees = await query
                .OrderByDescending(e => e.User.CreateDate)
                .ApplyPagination(request)
                .Select(e => new EmployeeListDto
                {
                    Id = e.Id,
                    FirstName = e.User.FirstName,
                    LastName = e.User.LastName,
                    Email = e.User.Email,
                    PositionName = e.User.OperationClaim.Name,
                    PositionDisplayName = e.User.OperationClaim.DisplayName,
                    BranchName = e.Branch.Name,
                    HireDate = e.HireDate,
                    Salary = e.EmployeeSalaries
                    .OrderByDescending(s => s.CreateDate)
                    .Select(s => (decimal?)s.GrossSalary)
                    .FirstOrDefault(),
                    WorkStatusName = e.WorkStatus.ToString(),
                    WorkStatusDisplayName = e.WorkStatus.GetDisplayName(),
                })
                .ToListAsync(cancellationToken);


            return new(new()
            {
                TotalEmployees = statistics.TotalEmployees,
                ActiveEmployees = statistics.ActiveEmployees,
                Chefs = statistics.Chefs,
                Waiters = statistics.Waiters,
                Employees = new(employees, request, statistics.TotalEmployees)
            },
            CommonMessages.StatisticsFetched);
        }
    }
}
