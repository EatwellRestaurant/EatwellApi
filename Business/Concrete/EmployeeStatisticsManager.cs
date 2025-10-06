using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Core.Requests;
using Core.ResponseModels;
using Core.Utilities.Helpers;
using Entities.Dtos.Employee;
using Entities.Dtos.EmployeeSalary;
using Entities.Dtos.EmployeeTask;
using Entities.Enums.Employee;
using Entities.Enums.EmployeeTask;
using Entities.Enums.OperationClaim;

namespace Business.Concrete
{
    public class EmployeeStatisticsManager : IEmployeeStatisticsService
    {
        readonly IEmployeeService _employeeService;
        readonly IOperationClaimService _operationClaimService;
        readonly IBranchService _branchService;
        readonly IEmployeeSalaryService _employeeSalaryService;

        public EmployeeStatisticsManager
            (IEmployeeService employeeService, 
            IOperationClaimService operationClaimService, 
            IBranchService branchService, 
            IEmployeeSalaryService employeeSalaryService)
        {
            _employeeService = employeeService;
            _operationClaimService = operationClaimService;
            _branchService = branchService;
            _employeeSalaryService = employeeSalaryService;
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
        public async Task<EmployeeFilterOptionsDto> GetEmployeeFilterOptionsAsync()
            => new()
            {
                WorkStatusDtos = EnumHelper.ToLookupList<WorkStatusType, WorkStatusDto>(),
                OperationClaimListDtos = await _operationClaimService.GetAllAsync(),
                BranchDtos = await _branchService.GetAllForAdminLookupAsync()
            };
        




        [SecuredOperation(OperationClaimEnum.Admin)]
        public async Task<EmployeeSalaryFilterOptionsDto> GetEmployeeSalaryFilterOptionsAsync(int employeeId)
            => new()
            {
                PaymentStatusDtos = EnumHelper.ToLookupList<PaymentStatusEnum, PaymentStatusDto>(),
                YearListDtos = await _employeeSalaryService.GetEmployeeSalaryYearsAsync(employeeId)
            };
        
        
        
        
        
        [SecuredOperation(OperationClaimEnum.Admin)]
        public EmployeeTaskFilterOptionsDto GetEmployeeTaskFilterOptionsAsync()
            => new()
            {
                PriorityLevelDtos = EnumHelper.ToLookupList<PriorityLevelEnum, PriorityLevelDto>(),
                TaskStatusDtos = EnumHelper.ToLookupList<TaskStatusEnum, TaskStatusDto>()
            };
        
    }
}
