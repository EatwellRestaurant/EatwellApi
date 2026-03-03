using EatwellApi.Application.Abstractions.Services.Employee;
using EatwellApi.Application.Constants.Messages;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.OperationClaim;
using MediatR;

namespace EatwellApi.Application.Features.Queries.Employee.GetOverview
{
    public class GetEmployeesOverviewQueryHandler : IRequestHandler<GetEmployeesOverviewQueryRequest, DataResponse<EmployeesOverviewDto>>
    {
        readonly IEmployeeService _employeeService;

        public GetEmployeesOverviewQueryHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }



        public async Task<DataResponse<EmployeesOverviewDto>> Handle(GetEmployeesOverviewQueryRequest request, CancellationToken cancellationToken)
            => new(new()
            {
                TotalEmployees = await _employeeService.CountEmployeesAsync(),
                ActiveEmployees = await _employeeService.CountActiveEmployeesAsync(),
                Chefs = await _employeeService.CountEmployeesAsync(OperationClaimEnum.Chef),
                Waiters = await _employeeService.CountEmployeesAsync(OperationClaimEnum.Waiter),
                Employees = await _employeeService.GetPagedEmployeesAsync(request)
            },
                CommonMessages.StatisticsFetch);

    }
}
