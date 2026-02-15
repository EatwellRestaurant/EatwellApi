using EatwellApi.Application.Abstractions.Repositories.Employee;
using EatwellApi.Application.Abstractions.Services.Employee;
using EatwellApi.Domain.Enums.OperationClaim;

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
            => await _readRepository.CountAsync(e => !claimEnum.HasValue || e.User.OperationClaimId == (int)claimEnum && !e.User.IsDeleted);
    
    }
}
