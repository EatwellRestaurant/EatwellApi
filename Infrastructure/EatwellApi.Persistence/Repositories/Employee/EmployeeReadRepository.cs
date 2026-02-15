using EatwellApi.Application.Abstractions.Repositories.Employee;
using EatwellApi.Persistence.Context;
using DomainEmployee = EatwellApi.Domain.Entities.Employee;

namespace EatwellApi.Persistence.Repositories.Employee
{
    public class EmployeeReadRepository : ReadRepository<DomainEmployee>, IEmployeeReadRepository
    {
        public EmployeeReadRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
