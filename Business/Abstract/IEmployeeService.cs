using Core.Requests;
using Core.ResponseModels;
using Entities.Concrete;
using Entities.Dtos.Employee;
using Entities.Enums.OperationClaim;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService : IService<Employee>
    {
        Task<CreateSuccessResponse> AddForManagerAsync(EmployeeUpsertDto employeeUpsertDto);

        Task<CreateSuccessResponse> AddForAdminAsync(EmployeeUpsertDtoForAdmin employeeUpsertDto);

        Task<PaginationResponse<EmployeeListDto>> GetAllForManagerAsync(PaginationRequest paginationRequest);

        Task<PaginationResponse<EmployeeListDto>> GetAllForAdminAsync(PaginationRequest paginationRequest);

        Task<DataResponse<int>> GetTotalEmployeeCount();

        Task<DataResponse<int>> GetActiveEmployeeCount();

        Task<DataResponse<int>> GetEmployeeCountByClaim(OperationClaimEnum operationClaimEnum);

        Task<PaginationResponse<EmployeeListDto>> GetFilteredEmployeesForManagerAsync(PaginationRequest paginationRequest, EmployeeFilterRequestDto employeeFilterRequestDto);

        Task<PaginationResponse<EmployeeListDto>> GetFilteredEmployeesForAdminAsync(PaginationRequest paginationRequest, EmployeeAdminFilterDto employeeAdminFilterDto);


    }
}
