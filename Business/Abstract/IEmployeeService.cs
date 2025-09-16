using Core.Requests;
using Core.ResponseModels;
using Entities.Concrete;
using Entities.Dtos.Employee;
using Entities.Enums.OperationClaim;
using Microsoft.AspNetCore.Http;
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
        Task<CreateSuccessResponse> UploadImageAsync(int employeeId, IFormFile image);

        Task<CreateSuccessResponse> AddForManagerAsync(EmployeeUpsertDto employeeUpsertDto);

        Task<CreateSuccessResponse> AddForAdminAsync(EmployeeUpsertDtoForAdmin employeeUpsertDto);

        Task<PaginationResponse<EmployeeListDto>> GetAllForManagerAsync(PaginationRequest paginationRequest);

        Task<PaginationResponse<EmployeeListDto>> GetAllForAdminAsync(PaginationRequest paginationRequest);

        Task<DataResponse<int>> GetTotalEmployeeCount();

        Task<DataResponse<int>> GetActiveEmployeeCount();

        Task<DataResponse<int>> GetEmployeeCountByClaim(OperationClaimEnum operationClaimEnum);

        Task<PaginationResponse<EmployeeListDto>> GetFilteredEmployeesForManagerAsync(PaginationRequest paginationRequest, EmployeeFilterRequestDto employeeFilterRequestDto);

        Task<PaginationResponse<EmployeeListDto>> GetFilteredEmployeesForAdminAsync(PaginationRequest paginationRequest, EmployeeAdminFilterDto employeeAdminFilterDto);

        Task<DataResponse<EmployeeDetailDto>> GetForAdminAsync(int employeeId);

        Task<DataResponse<EmployeeDetailDto>> GetForManagerAsync(int employeeId);

    }
}
