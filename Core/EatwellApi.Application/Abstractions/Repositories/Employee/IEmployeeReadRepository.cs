using DomainEmployee = EatwellApi.Domain.Entities.Employee;

namespace EatwellApi.Application.Abstractions.Repositories.Employee
{
    public interface IEmployeeReadRepository : IReadRepository<DomainEmployee>
    {
    }
}
