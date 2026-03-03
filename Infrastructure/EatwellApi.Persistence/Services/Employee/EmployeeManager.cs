using EatwellApi.Application.Abstractions.Repositories.Employee;
using EatwellApi.Application.Abstractions.Services.Employee;
using EatwellApi.Application.Dtos.Employee;
using EatwellApi.Application.Extensions;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.Employee;
using EatwellApi.Domain.Enums.OperationClaim;
using Microsoft.EntityFrameworkCore;
using DomainEmployee = EatwellApi.Domain.Entities.Employee;

namespace EatwellApi.Persistence.Services.Employee
{
    public class EmployeeManager : IEmployeeService
    {
        readonly IEmployeeReadRepository _readRepository;

        public EmployeeManager(IEmployeeReadRepository readRepository)
        {
            _readRepository = readRepository;
        }
         


        public async Task<int> CountEmployeesAsync(OperationClaimEnum? claimEnum = null)
            => await _readRepository
            .CountAsync(e => (!claimEnum.HasValue || e.User.OperationClaimId == (int)claimEnum) && !e.User.IsDeleted);




        public async Task<int> CountActiveEmployeesAsync()
            => await _readRepository
            .CountAsync(e => !e.User.IsDeleted && e.WorkStatus == WorkStatusType.Active);




        public async Task<PaginationResponse<EmployeeListDto>> GetPagedEmployeesAsync(PaginationRequest paginationRequest)
        {
            IQueryable<DomainEmployee> query = _readRepository
                .GetAllQueryable(e => !e.User.IsDeleted)
                .Include(e => e.EmployeeSalaries.Where(e => !e.IsDeleted));


            List<EmployeeListDto> employeeListDtos = await ProjectToEmployeeListAsync(query, paginationRequest);


            return new(employeeListDtos, paginationRequest, employeeListDtos.Count);
        }




         


        #region Private Methods

        private async Task<List<EmployeeListDto>> ProjectToEmployeeListAsync(IQueryable<DomainEmployee> query, PaginationRequest paginationRequest)
          => await query
           .OrderByDescending(e => e.Id)
           .ApplyPagination(paginationRequest)
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
           .ToListAsync();

        #endregion
    }
}
