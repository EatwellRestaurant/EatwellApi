using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Core.Extensions;
using Core.Requests;
using Core.ResponseModels;
using Entities.Dtos.Branch;
using Entities.Dtos.Employee;
using Entities.Dtos.EmployeeSalary;
using Entities.Dtos.OperationClaim;
using Entities.Dtos.Year;
using Entities.Enums.Employee;
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
        {
            List<WorkStatusDto> workStatusDtos = Enum.GetValues(typeof(WorkStatusType)) // WorkStatusType içindeki tüm enum değerlerini döndüren bir System.Array üretiyoruz
            .Cast<WorkStatusType>() // Array içindeki öğeleri WorkStatusType türüne cast edip IEnumerable<WorkStatusType> haline getiriyoruz. Böylece LINQ uzantı metodlarını kullanabiliyoruz.
            .Select(status => new WorkStatusDto
            {
                Id = (byte)status,
                Name = status.GetDisplayName()
            })
            .ToList();


            List<OperationClaimListDto> operationClaimListDtos = await _operationClaimService.GetAllAsync();
            List<BaseBranchDto> branchDtos = await _branchService.GetAllForAdminLookupAsync();


            return new()
            {
                WorkStatusDtos = workStatusDtos,
                OperationClaimListDtos = operationClaimListDtos,
                BranchDtos = branchDtos
            };
        }




        [SecuredOperation(OperationClaimEnum.Admin)]
        public async Task<EmployeeSalaryFilterOptionsDto> GetEmployeeSalaryFilterOptionsAsync(int employeeId)
        {
            List<PaymentStatusDto> paymentStatusDtos = Enum.GetValues(typeof(PaymentStatusEnum))
            .Cast<PaymentStatusEnum>() 
            .Select(status => new PaymentStatusDto
            {
                Id = (byte)status,
                Name = status.GetDisplayName()
            })
            .ToList();


            List<YearListDto> yearListDtos = await _employeeSalaryService.GetEmployeeSalaryYearsAsync(employeeId);


            return new()
            {
                PaymentStatusDtos = paymentStatusDtos,
                YearListDtos = yearListDtos
            };
        }

    }
}
