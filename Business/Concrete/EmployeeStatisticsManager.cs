using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Core.Requests;
using Core.ResponseModels;
using Core.Utilities.Helpers;
using Entities.Dtos.Employee;
using Entities.Enums.Employee;
using Entities.Enums.OperationClaim;

namespace Business.Concrete
{
    public class EmployeeStatisticsManager : IEmployeeStatisticsService
    {
        readonly IEmployeeService _employeeService;
        readonly IOperationClaimService _operationClaimService;
        readonly IBranchService _branchService;

        public EmployeeStatisticsManager
            (IEmployeeService employeeService, 
            IOperationClaimService operationClaimService, 
            IBranchService branchService)
        {
            _employeeService = employeeService;
            _operationClaimService = operationClaimService;
            _branchService = branchService;
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
    
    


        [SecuredOperation(OperationClaimEnum.Admin)] 
        public async Task<DataResponse<EmployeeFilterOptionsDto>> GetEmployeeFilterOptionsAsync()
            => new(
                new()
                {
                    WorkStatusDtos = EnumHelper.ToLookupList<WorkStatusType, WorkStatusDto>(),
                    OperationClaimListDtos = await _operationClaimService.GetAllAsync(),
                    BranchDtos = await _branchService.GetAllForAdminLookupAsync()
                });
        


        
    }
}
