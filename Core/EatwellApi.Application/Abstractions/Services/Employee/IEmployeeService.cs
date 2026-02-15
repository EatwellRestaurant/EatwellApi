using EatwellApi.Domain.Enums.OperationClaim;

namespace EatwellApi.Application.Abstractions.Services.Employee
{
    public interface IEmployeeService 
    {
        Task<int> CountEmployeesAsync(OperationClaimEnum? claimEnum = null);
    }
}
