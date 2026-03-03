using EatwellApi.Application.Dtos.Employee;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.OperationClaim;

namespace EatwellApi.Application.Abstractions.Services.Employee
{
    public interface IEmployeeService 
    {
        Task<int> CountEmployeesAsync(OperationClaimEnum? claimEnum = null);
        
        Task<int> CountActiveEmployeesAsync();

        Task<PaginationResponse<EmployeeListDto>> GetPagedEmployeesAsync(PaginationRequest paginationRequest);
    }
}
