using AutoMapper;
using AutoMapper.QueryableExtensions;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.Extensions;
using Business.ValidationRules.FluentValidation.Employee;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions.Employee;
using Core.Exceptions.General;
using Core.Extensions;
using Core.Requests;
using Core.ResponseModels;
using Core.Utilities.FileHelper;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Employee;
using Entities.Dtos.Product;
using Entities.Enums.Employee;
using Entities.Enums.OperationClaim;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Service.Concrete;
using System.Security.Claims;

namespace Business.Concrete
{
    public class EmployeeManager : Manager<Employee>, IEmployeeService
    {
        readonly IEmployeeDal _employeeDal;
        readonly IMapper _mapper;
        readonly IUserService _userService;
        readonly IUnitOfWork _unitOfWork;
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IOperationClaimService _operationClaimService;
        readonly IBranchService _branchService;
        readonly ICityService _cityService;
        readonly IFileHelper _fileHelper;

        public EmployeeManager
            (IEmployeeDal employeeDal,
            IMapper mapper,
            IUserService userService,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            IOperationClaimService operationClaimService,
            IBranchService branchService,
            ICityService cityService,
            IFileHelper fileHelper)
            : base(employeeDal)
        {
            _employeeDal = employeeDal;
            _mapper = mapper;
            _userService = userService;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _operationClaimService = operationClaimService;
            _branchService = branchService;
            _cityService = cityService;
            _fileHelper = fileHelper;
        }



        [SecuredOperation(OperationClaimEnum.Manager, Priority = 1)]
        [ValidationAspect(typeof(EmployeeUpsertDtoValidator), Priority = 2)]
        public async Task<CreateSuccessResponse> AddForManagerAsync(EmployeeUpsertDto employeeUpsertDto)
        {
            int userId = GetCurrentUserId();
            int branchId = await GetBranchIdByUserIdAsync(userId);


            await ValidateEmployeeReferencesAsync(branchId, employeeUpsertDto);


            OperationClaimEnum[] rolesToCheck = new[]
            {
                OperationClaimEnum.Admin,
                OperationClaimEnum.Manager,
                OperationClaimEnum.User
            };


            await ValidateRoleAssignment(rolesToCheck, employeeUpsertDto.OperationClaimId, OperationClaimEnum.Manager);
            await CreateEmployeeWithUserAsync(employeeUpsertDto, branchId);


            return new CreateSuccessResponse(CommonMessages.EntityAdded);
        }




        [SecuredOperation(OperationClaimEnum.Admin, Priority = 1)]
        [ValidationAspect(typeof(EmployeeUpsertDtoForAdminValidator), Priority = 2)]
        public async Task<CreateSuccessResponse> AddForAdminAsync(EmployeeUpsertDtoForAdmin employeeUpsertDto)
        {
            await ValidateEmployeeReferencesAsync(employeeUpsertDto.BranchId, employeeUpsertDto);


            OperationClaimEnum[] rolesToCheck = new[]
            {
                OperationClaimEnum.Admin
            };


            string targetRole = await ValidateRoleAssignment(rolesToCheck, employeeUpsertDto.OperationClaimId, OperationClaimEnum.Admin);


            if (string.Equals(targetRole, OperationClaimEnum.Manager.ToString(), StringComparison.OrdinalIgnoreCase)
                &&
                await _branchService.HasManagerAsync(employeeUpsertDto.BranchId))
                throw new BranchAlreadyHasManagerException();


            await CreateEmployeeWithUserAsync(employeeUpsertDto, employeeUpsertDto.BranchId);


            return new CreateSuccessResponse(CommonMessages.EntityAdded);
        }




        [SecuredOperation(OperationClaimEnum.Manager)]
        public async Task<PaginationResponse<EmployeeListDto>> GetAllForManagerAsync(PaginationRequest paginationRequest)
        {
            int userId = GetCurrentUserId();

            int branchId = await GetBranchIdByUserIdAsync(userId);


            await _branchService.CheckIfBranchIdExists(branchId);

            IQueryable<Employee> query = _employeeDal
                .GetAllQueryable(e => !e.User.IsDeleted)
                .FilterByBranchId(branchId)
                .FilterByUserId(userId);


            List<EmployeeListDto> employeeListDtos = await GetEmployeeListByBranchAsync(query, paginationRequest);


            return new PaginationResponse<EmployeeListDto>(employeeListDtos, paginationRequest, employeeListDtos.Count);
        }




        [SecuredOperation(OperationClaimEnum.Admin)]
        public async Task<PaginationResponse<EmployeeListDto>> GetAllForAdminAsync(PaginationRequest paginationRequest)
        {
            IQueryable<Employee> query = _employeeDal
                .GetAllQueryable(e => !e.User.IsDeleted);


            List<EmployeeListDto> employeeListDtos = await GetEmployeeListByBranchAsync(query, paginationRequest);


            return new PaginationResponse<EmployeeListDto>(employeeListDtos, paginationRequest, employeeListDtos.Count);
        }




        [SecuredOperation(OperationClaimEnum.Admin)]
        public async Task<DataResponse<EmployeeDetailDto>> GetForAdminAsync(int employeeId)
        {
            IQueryable<Employee> query = _employeeDal
                .Where(e => e.Id == employeeId && !e.User.IsDeleted);


            return new DataResponse<EmployeeDetailDto>(
                _mapper.Map<EmployeeDetailDto>(await GetEmployeeWithManagerAsync(query)), 
                CommonMessages.EntityFetch);
        }




        [SecuredOperation(OperationClaimEnum.Manager)]
        public async Task<DataResponse<EmployeeDetailDto>> GetForManagerAsync(int employeeId)
        {
            int userId = GetCurrentUserId();
            int branchId = await GetBranchIdByUserIdAsync(userId);

            await _branchService.CheckIfBranchIdExists(branchId);


            IQueryable<Employee> query = _employeeDal
                .Where(e => e.Id == employeeId && !e.User.IsDeleted)
                .FilterByBranchId(branchId)
                .FilterByUserId(userId);

            
            return new DataResponse<EmployeeDetailDto>(
                _mapper.Map<EmployeeDetailDto>(await GetEmployeeWithManagerAsync(query)), 
                CommonMessages.EntityFetch);
        }




        [SecuredOperation(OperationClaimEnum.Admin)]
        public async Task<PaginationResponse<EmployeeListDto>> GetFilteredEmployeesForAdminAsync(PaginationRequest paginationRequest, EmployeeAdminFilterDto employeeAdminFilterDto)
        {
            IQueryable<Employee> query = _employeeDal
                .GetAllQueryable(e => !e.User.IsDeleted)
                .FilterByBranchId(employeeAdminFilterDto.BranchId)
                .FilterByOperationClaimId(employeeAdminFilterDto.OperationClaimId)
                .FilterByWorkStatus(employeeAdminFilterDto.WorkStatus)
                .FilterByFullName(employeeAdminFilterDto.FullName);


            List<EmployeeListDto> employeeListDtos = await GetEmployeeListByBranchAsync(query, paginationRequest);


            return new PaginationResponse<EmployeeListDto>(employeeListDtos, paginationRequest, employeeListDtos.Count);
        }




        [SecuredOperation(OperationClaimEnum.Manager)]
        public async Task<PaginationResponse<EmployeeListDto>> GetFilteredEmployeesForManagerAsync(PaginationRequest paginationRequest, EmployeeFilterRequestDto employeeFilterRequestDto)
        {
            IQueryable<Employee> query = _employeeDal
                .GetAllQueryable(e => !e.User.IsDeleted)
                .FilterByOperationClaimId(employeeFilterRequestDto.OperationClaimId)
                .FilterByWorkStatus(employeeFilterRequestDto.WorkStatus)
                .FilterByFullName(employeeFilterRequestDto.FullName);


            List<EmployeeListDto> employeeListDtos = await GetEmployeeListByBranchAsync(query, paginationRequest);


            return new PaginationResponse<EmployeeListDto>(employeeListDtos, paginationRequest, employeeListDtos.Count);
        }




        [SecuredOperation(OperationClaimEnum.Admin)]
        public async Task<DataResponse<int>> GetTotalEmployeeCount()
            => new DataResponse<int>(await _employeeDal
               .CountAsync(e => !e.User.IsDeleted));




        [SecuredOperation(OperationClaimEnum.Admin)]
        public async Task<DataResponse<int>> GetActiveEmployeeCount()
            => new DataResponse<int>(await _employeeDal
               .CountAsync(e => !e.User.IsDeleted && e.WorkStatus == WorkStatusType.Active));




        [SecuredOperation(OperationClaimEnum.Admin)]
        public async Task<DataResponse<int>> GetEmployeeCountByClaim(OperationClaimEnum operationClaimEnum)
            => new DataResponse<int>(await _employeeDal
               .CountAsync(e => !e.User.IsDeleted && e.User.OperationClaimId == (int)operationClaimEnum));






        #region OtherMethods

        private async Task<List<EmployeeListDto>> GetEmployeeListByBranchAsync(IQueryable<Employee> query, PaginationRequest paginationRequest)
           => await query
            .ApplyPagination(paginationRequest)
            .OrderByDescending(e => e.Id)
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
                Salary = e.Salary,
                WorkStatusName = e.WorkStatus.ToString(),
                WorkStatusDisplayName = e.WorkStatus.GetDisplayName(),
            })
            .ToListAsync();


        private async Task<Employee> GetEmployeeWithManagerAsync(IQueryable<Employee> query)
            => await query
            .Select(e => new Employee()
            {
                ImagePath = e.ImagePath,
                Phone = e.Phone,
                HireDate = e.HireDate,
                Salary = e.Salary,
                BirthDate = e.BirthDate,
                NationalId = e.NationalId,
                Gender = e.Gender,
                MaritalStatus = e.MaritalStatus,
                Address = e.Address,
                EmploymentType = e.EmploymentType,
                EducationLevel = e.EducationLevel,
                MilitaryStatus = e.MilitaryStatus,
                WorkStatus = e.WorkStatus,
                Branch = new Branch()
                {
                    Name = e.Branch.Name,
                    Employees = e.Branch.Employees
                        .Where(e => e.User.OperationClaimId == (int)OperationClaimEnum.Manager)
                        .Select(e => new Employee()
                        {
                            User = new User()
                            {
                                OperationClaimId = e.User.OperationClaimId,
                                FirstName = e.User.FirstName,
                                LastName = e.User.LastName,
                            },
                        })
                        .ToList()
                },
                User = new User()
                {
                    FirstName = e.User.FirstName,
                    LastName = e.User.LastName,
                    Email = e.User.Email,
                    OperationClaim = new OperationClaim()
                    {
                        Name = e.User.OperationClaim.Name,
                        DisplayName = e.User.OperationClaim.DisplayName
                    }
                }
            })
            .AsNoTracking()
            .SingleOrDefaultAsync()
            ?? throw new EntityNotFoundException("Çalışan");


        private async Task<int> GetBranchIdByUserIdAsync(int userId)
            => await _employeeDal
            .Where(e => e.UserId == userId)
            .Select(e => e.BranchId)
            .SingleAsync();


        private async Task ValidateEmployeeReferencesAsync(int branchId, EmployeeUpsertDto employeeUpsertDto)
        {
            await _branchService.CheckIfBranchIdExists(branchId);

            await _userService.CheckIfUserEMail(employeeUpsertDto.Email);

            await _operationClaimService.CheckIfOperationClaimIdExists(employeeUpsertDto.OperationClaimId);

            await _cityService.CheckIfCityIdExists(employeeUpsertDto.CityId);
        }


        private async Task<string> ValidateRoleAssignment(OperationClaimEnum[] rolesToCheck, int operationClaimId, OperationClaimEnum currentUserRole)
        {
            string targetRole = await _operationClaimService.GetClaim(operationClaimId);


            OperationClaimEnum matchedRole = rolesToCheck
                .FirstOrDefault(r => targetRole.Equals(r.ToString(), StringComparison.OrdinalIgnoreCase));


            if (matchedRole != default)
                throw new UnauthorizedRoleAssignmentException(currentUserRole.GetDisplayName(), matchedRole.GetDisplayName());


            return targetRole;
        }


        private async Task CreateEmployeeWithUserAsync(EmployeeUpsertDto employeeUpsertDto, int branchId)
        {
            User user = _mapper.Map<User>(employeeUpsertDto);
            Employee employee = _mapper.Map<Employee>(employeeUpsertDto);


            if (employeeUpsertDto.Image != null)
            {
                ImageRespone imageRespone = await _fileHelper.Upload(employeeUpsertDto.Image);
                employee.ImagePath = imageRespone.Path;
                employee.ImageName = imageRespone.Name;
            }

            await _userService.AddAsync(user);
            await _employeeDal.AddAsync(employee);

            user.Employee = employee;
            employee.BranchId = branchId;

            await _unitOfWork.SaveChangesAsync();
        }


        private int GetCurrentUserId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User
                .Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
        }

        #endregion

    }
}
