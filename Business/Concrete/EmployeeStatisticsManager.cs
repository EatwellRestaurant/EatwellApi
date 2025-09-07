using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Core.Requests;
using Core.ResponseModels;
using Entities.Dtos.Branch;
using Entities.Dtos.Employee;
using Entities.Enums.OperationClaim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeStatisticsManager : IEmployeeStatisticsService
    {
        readonly IEmployeeService _employeeService;

        public EmployeeStatisticsManager(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }



        [SecuredOperation(OperationClaimEnum.Admin)]
        public async Task<DataResponse<EmployeeStatisticsDto>> GetStatistics(PaginationRequest paginationRequest)
        {
            DataResponse<int> employeeCount = await _employeeService.GetTotalEmployeeCount();
            DataResponse<int> activeEmployeeCount = await _employeeService.GetActiveEmployeeCount();
            DataResponse<int> chefCount = await _employeeService.GetEmployeeCountByClaim(OperationClaimEnum.Chef);
            DataResponse<int> waiterCount = await _employeeService.GetEmployeeCountByClaim(OperationClaimEnum.Waiter);
            PaginationResponse<EmployeeListDto> employeeListDtos = await _employeeService.GetAllForAdminAsync(paginationRequest);


            return new(
                new()
                {
                    EmployeeCount = employeeCount.Data,
                    ActiveEmployeeCount = activeEmployeeCount.Data,
                    ChefCount = chefCount.Data,
                    WaiterCount = waiterCount.Data,
                    EmployeeListDtos = employeeListDtos
                }, 
                CommonMessages.StatisticsFetch);
        }
    }
}
