using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Extensions;
using Business.ValidationRules.FluentValidation.EmployeeSalary;
using Core.Aspects.Autofac.Validation;
using Core.Extensions;
using Core.Requests;
using Core.ResponseModels;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Employee;
using Entities.Dtos.EmployeeSalary;
using Entities.Dtos.Year;
using Entities.Enums.OperationClaim;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class EmployeeSalaryManager : IEmployeeSalaryService
    {
        readonly IEmployeeSalaryDal _employeeSalaryDal;
        readonly IEmployeeService _employeeService;
        readonly IYearService _yearService;
        readonly IMapper _mapper;

        public EmployeeSalaryManager
            (IEmployeeSalaryDal employeeSalaryDal,
            IEmployeeService employeeService,
            IYearService yearService,
            IMapper mapper)
        {
            _employeeSalaryDal = employeeSalaryDal;
            _employeeService = employeeService;
            _yearService = yearService;
            _mapper = mapper;
        }


        [SecuredOperation(OperationClaimEnum.Admin, Priority = 1)]
        [ValidationAspect(typeof(EmployeeSalaryFilterRequestDtoValidator), Priority = 2)]
        public async Task<PaginationResponse<EmployeeFinancialListDto>> GetEmployeeSalaryFilteredAsync
            (int employeeId, EmployeeSalaryFilterRequestDto employeeSalaryFilterRequestDto, PaginationRequest paginationRequest)
        {
            await _employeeService.CheckIfEmployeeIdExists(employeeId);


            if (employeeSalaryFilterRequestDto.YearId.HasValue)
                await _yearService.CheckIfYearIdExists((int)employeeSalaryFilterRequestDto.YearId);


            IQueryable<EmployeeSalary> query = _employeeSalaryDal
                .Where(e => !e.IsDeleted)
                .FilterByEmployeeId(employeeId)
                .FilterByYearId(employeeSalaryFilterRequestDto.YearId)
                .FilterByPaymentStatus(employeeSalaryFilterRequestDto.PaymentStatus)
                .AsNoTracking()
                .OrderByDescending(p => p.CreateDate);


            List<EmployeeSalary> employeeSalaries = await query
                .ApplyPagination(paginationRequest)
                .Select(e => new EmployeeSalary
                {
                    Id = e.Id,
                    BaseSalary = e.BaseSalary,
                    GrossSalary = e.GrossSalary,
                    MealAllowance = e.MealAllowance,
                    TransportAllowance = e.TransportAllowance,
                    EducationAllowance = e.EducationAllowance,
                    PaymentStatus = e.PaymentStatus,
                    Month = new Month()
                    {
                        Name = e.Month.Name,
                        Year = new Year() { Name = e.Month.Year.Name },
                        EmployeeBonuses = e.Month.EmployeeBonuses
                        .Where(e => !e.IsDeleted)
                        .Select(eb => new EmployeeBonus()
                        {
                            Id = eb.Id,
                            BonusType = eb.BonusType,
                            Amount = eb.Amount,
                            PaymentStatus = eb.PaymentStatus
                        })
                        .ToList(),

                        EmployeeDeductions = e.Month.EmployeeDeductions
                        .Where(e => !e.IsDeleted)
                        .Select(ed => new EmployeeDeduction()
                        {
                            Id = ed.Id,
                            DeductionType = ed.DeductionType,
                            Amount = ed.Amount,
                            PaymentStatus = ed.PaymentStatus
                        })
                        .ToList()
                    }
                })
                .ToListAsync();

            
            List<EmployeeFinancialListDto> employeeFinancialListDtos =  _mapper.Map<List<EmployeeFinancialListDto>>(employeeSalaries);


            return new PaginationResponse<EmployeeFinancialListDto>(
                employeeFinancialListDtos,
                paginationRequest,
                await query.CountAsync());
        }





         
        [SecuredOperation(OperationClaimEnum.Admin)]
        public async Task<List<YearListDto>> GetEmployeeSalaryYearsAsync(int employeeId)
        {
            await _employeeService.CheckIfEmployeeIdExists(employeeId);


            return await _employeeSalaryDal
                .Where(e => !e.IsDeleted)
                .FilterByEmployeeId(employeeId)
                .AsNoTracking()
                .Select(e => new YearListDto()
                {
                    Id = e.Month.YearId,
                    Name = e.Month.Year.Name,
                })
                .Distinct()
                .ToListAsync();
        }
    }
}
