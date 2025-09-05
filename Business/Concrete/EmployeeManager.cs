using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation.Employee;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions.Employee;
using Core.ResponseModels;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Employee;
using Microsoft.AspNetCore.Http;
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

        public EmployeeManager
            (IEmployeeDal employeeDal,
            IMapper mapper,
            IUserService userService,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            IOperationClaimService operationClaimService,
            IBranchService branchService,
            ICityService cityService)
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
        }



        [SecuredOperation("admin, manager", Priority = 1)]
        [ValidationAspect(typeof(EmployeeUpsertDtoValidator), Priority = 2)]
        public async Task<CreateSuccessResponse> Add(EmployeeUpsertDto employeeUpsertDto)
        {
            await _branchService.CheckIfBranchIdExists(employeeUpsertDto.BranchId);
            
            await _operationClaimService.CheckIfOperationClaimIdExists(employeeUpsertDto.OperationClaimId);
            
            await _cityService.CheckIfCityIdExists(employeeUpsertDto.CityId);


            string targetRole = await _operationClaimService.GetClaim(employeeUpsertDto.OperationClaimId);

            string currentUserRole = GetCurrentUserRole();

            if (currentUserRole == "manager")
            {
                if (targetRole.ToLower() == "admin")
                    throw new UnauthorizedRoleAssignmentException("admin");

                else if (targetRole.ToLower() == "manager")
                    throw new UnauthorizedRoleAssignmentException("müdür");
            }


            await _userService.CheckIfUserEMail(employeeUpsertDto.Email);

            User user = _mapper.Map<User>(employeeUpsertDto);
            Employee employee = _mapper.Map<Employee>(employeeUpsertDto);

            await _userService.AddAsync(user);
            await _employeeDal.AddAsync(employee);

            user.Employee = employee;
            await _unitOfWork.SaveChangesAsync();

            return new CreateSuccessResponse(CommonMessages.EntityAdded);
        }





        private string GetCurrentUserRole()
        {
            return _httpContextAccessor.HttpContext.User
                .Claims.First(c => c.Type == ClaimTypes.Role).Value.ToLower();
        }
    }
}
