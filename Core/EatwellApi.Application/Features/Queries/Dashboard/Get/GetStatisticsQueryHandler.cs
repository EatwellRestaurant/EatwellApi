using EatwellApi.Application.Abstractions.Services.Employee;
using EatwellApi.Application.Abstractions.Services.Reservation;
using EatwellApi.Application.Abstractions.Services.User;
using EatwellApi.Application.Dtos.Dashboard;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.OperationClaim;
using MediatR;

namespace EatwellApi.Application.Features.Queries.Dashboard.Get
{
    public class GetStatisticsQueryHandler : IRequestHandler<GetStatisticsQueryRequest, DataResponse<DashboardStatisticsDto>>
    {
        readonly IUserService _userService;
        readonly IEmployeeService _employeeService;
        readonly IReservationService _reservationService;

        public GetStatisticsQueryHandler(IUserService userService, IEmployeeService employeeService, IReservationService reservationService)
        {
            _userService = userService;
            _employeeService = employeeService;
            _reservationService = reservationService;
        }



        public async Task<DataResponse<DashboardStatisticsDto>> Handle(GetStatisticsQueryRequest request, CancellationToken cancellationToken)
            => new(new()
            {
                UserCount = await _userService.CountUsersByClaimAsync(OperationClaimEnum.User),
                ReservationCount = await _reservationService.CountReservationsAsync(),
                EmployeeCount = await _employeeService.CountEmployeesAsync(),
            });
    }
}
