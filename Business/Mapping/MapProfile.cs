using AutoMapper;
using Core.Entities.Abstract;
using Core.Extensions;
using Entities.Concrete;
using Entities.Dtos.Branch;
using Entities.Dtos.City;
using Entities.Dtos.Employee;
using Entities.Dtos.EmployeeBonus;
using Entities.Dtos.EmployeeDeduction;
using Entities.Dtos.EmployeeSalary;
using Entities.Dtos.HeadOffice;
using Entities.Dtos.MealCategory;
using Entities.Dtos.OperationClaim;
using Entities.Dtos.Order;
using Entities.Dtos.PageContent;
using Entities.Dtos.Permission;
using Entities.Dtos.Product;
using Entities.Dtos.Reservation;
using Entities.Dtos.ShiftDay;
using Entities.Dtos.Table;
using Entities.Dtos.User;
using Entities.Enums;
using Entities.Enums.Employee;
using Entities.Enums.OperationClaim;
using Entities.Enums.Permission;
using Microsoft.EntityFrameworkCore.SqlServer.Internal;

namespace Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {

            #region User

            CreateMap<UserUpdateDto, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => DateTime.Now));


            CreateMap<EmployeeUpsertDto, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)));


            CreateMap<User, UserListDto>();


            CreateMap<User, UserDetailDto>();

            #endregion



            #region MealCategory

            CreateMap<MealCategory, MealCategoryListDto>();


            CreateMap<MealCategory, MealCategoryDetailDto>();

            #endregion



            #region City

            CreateMap<City, CityDto>();


            CreateMap<City, CityWithBranchesDto>();


            CreateMap<City, CityWithBranchCountDto>()
                .ForMember(dest => dest.BranchCount, opt => opt.MapFrom(src => src.Branches.Count));

            #endregion



            #region Branch

            CreateMap<Branch, BranchDto>();


            CreateMap<Branch, BranchListDto>();


            CreateMap<Branch, SalesBranchDto>();


            CreateMap<Branch, NonSalesBranchDto>();


            CreateMap<Branch, PendingBranchDto>()
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.GetDisplayName()));


            CreateMap<Branch, BranchListWithCityDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name));


            CreateMap<BranchInsertDto, Branch>();


            CreateMap<BranchUpdateDto, Branch>();


            CreateMap<Branch, BranchDetailDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name));

            #endregion



            #region Reservation

            CreateMap<ReservationUpsertDto, Reservation>();


            CreateMap<Reservation, ReservationListDto>()
                .ForMember(dest => dest.TableNo, opt => opt.MapFrom(src => src.Table.No));


            CreateMap<Reservation, ReservationDetailDto>()
                .IncludeBase<Reservation, ReservationListDto>();


            #endregion



            #region Table

            CreateMap<TableInsertDto, Table>();


            CreateMap<TableUpdateDto, Table>();


            CreateMap<Table, TableListDto>();

            #endregion



            #region Product

            CreateMap<Product, ProductAdminListDto>();


            CreateMap<Product, ProductListWithMealCategoryDto>()
                .ForMember(dest => dest.MealCategoryName, opt => opt.MapFrom(src => src.MealCategory.Name));


            CreateMap<Product, ProductDetailDto>();


            CreateMap<Product, ProductDisplayDto>();

            #endregion



            #region PageContent

            CreateMap<PageContent, PageContentListDto>()
                .ForMember(dest => dest.SectionId, opt => opt.MapFrom(src => src.Section))
                .ForMember(dest => dest.SectionName, opt => opt.MapFrom(src => ((SectionEnum)src.Section).ToString()));

            #endregion




            #region Order

            CreateMap<OrderInsertDto, Order>();

            #endregion



            #region HeadOffice     

            CreateMap<HeadOffice, HeadOfficeDto>()
                .ReverseMap();

            #endregion



            #region Employee        

            CreateMap<EmployeeUpsertDto, Employee>()
                .ForMember(dest => dest.MilitaryStatus, opt => opt.MapFrom(src => src.Gender == GenderType.Female ? null : src.MilitaryStatus));


            ICollection<EmployeeDeduction>? employeeDeductions = null;
            ICollection<EmployeeBonus>? employeeBonus = null;

            CreateMap<Employee, EmployeeDetailDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.GetDisplayName()))
                .ForMember(dest => dest.MilitaryStatus, opt => opt.MapFrom(src => src.MilitaryStatus != null ? src.MilitaryStatus.GetDisplayName() : null))
                .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus.GetDisplayName()))
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.User.OperationClaim.Name))
                .ForMember(dest => dest.PositionDisplayName, opt => opt.MapFrom(src => src.User.OperationClaim.DisplayName))
                .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus.GetDisplayName()))
                .ForMember(dest => dest.EmploymentType, opt => opt.MapFrom(src => src.EmploymentType.GetDisplayName()))
                .ForMember(dest => dest.EducationLevel, opt => opt.MapFrom(src => src.EducationLevel.GetDisplayName()))
                .ForMember(dest => dest.WorkStatusName, opt => opt.MapFrom(src => src.WorkStatus.ToString()))
                .ForMember(dest => dest.WorkStatusDisplayName, opt => opt.MapFrom(src => src.WorkStatus.GetDisplayName()))
                .ForMember(dest => dest.ShiftDayDtos, opt => opt.MapFrom(src => src.ShiftDays))
                .ForMember(dest => dest.PermissionListDtos, opt => opt.MapFrom(src => src.Permissions))
                .ForMember(dest => dest.EmployeeBonusListDtos, opt => opt.MapFrom(src => src.EmployeeBonuses))
                .ForMember(dest => dest.EmployeeDeductionListDtos, opt => opt.MapFrom(src => src.EmployeeDeductions))
                .ForMember(dest => dest.EmployeeSalaryListDtos, opt => opt.MapFrom(src => src.EmployeeSalaries))
                .BeforeMap((src, dest) =>
                {
                    employeeDeductions = src.EmployeeDeductions;
                    employeeBonus = src.EmployeeBonuses;

                    DateTime today = DateTime.Now;

                    int years = today.Year - src.HireDate.Year;
                    int months = today.Month - src.HireDate.Month;
                    int days = today.Day - src.HireDate.Day;

                    if (days < 0)
                    {
                        months--;

                        days += DateTime.DaysInMonth(today.AddMonths(-1).Year, today.AddMonths(-1).Month);
                    }

                    if (months < 0)
                    {
                        years--;
                        months += 12;
                    }

                    // ExperienceDuration string'ini oluşturuyoruz
                    var parts = new List<string>();

                    if (years > 0) parts.Add($"{years} yıl");
                    if (months > 0) parts.Add($"{months} ay");
                    if (days > 0) parts.Add($"{days} gün");

                    dest.ExperienceDuration = parts.Count > 0 ? string.Join(" ", parts) : "Bugün işe başladı.";


                    User? manager = src.Branch?.Employees
                        .Select(e => e.User)
                        .SingleOrDefault();


                    dest.Manager = manager != null
                        ? $"{manager.FirstName} {manager.LastName}"
                        : "Atanmış bir yönetici bulunmamaktadır.";
                });

            #endregion



            #region EmployeeSalary

            CreateMap<EmployeeSalary, EmployeeSalaryListDto>()
                .AfterMap((src, dest) =>
                {
                    decimal employeeBonusAmount = employeeBonus!
                    .Where(e => e.Year == src.Year && e.Month == src.Month)
                    .Sum(e => e.Amount);
                     

                    decimal employeeDeductionAmount = employeeDeductions!
                    .Where(e => e.Year == src.Year && e.Month == src.Month)
                    .Sum(e => e.Amount);


                    dest.NetSalary = src.GrossSalary + employeeBonusAmount - employeeDeductionAmount;
                });

            #endregion



            #region EmployeeBonus

            CreateMap<EmployeeBonus, EmployeeBonusListDto>()
                .ForMember(dest => dest.BonusType, opt => opt.MapFrom(src => src.BonusType.GetDisplayName()))
                .ForMember(dest => dest.PaymentStatusName, opt => opt.MapFrom(src => src.PaymentStatus.GetDisplayName()));

            #endregion



            #region EmployeeDeduction

            CreateMap<EmployeeDeduction, EmployeeDeductionListDto>()
                .ForMember(dest => dest.DeductionType, opt => opt.MapFrom(src => src.DeductionType.GetDisplayName()))
                .ForMember(dest => dest.PaymentStatusName, opt => opt.MapFrom(src => src.PaymentStatus.GetDisplayName()));

            #endregion



            #region ShiftDay  

            CreateMap<ShiftDayDto, ShiftDay>()
                .ReverseMap();

            #endregion



            #region Permission

            CreateMap<PermissionUpsertDto, Permission>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => StatusType.Pending));


            CreateMap<Permission, PermissionListDto>()
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.GetDisplayName()))
                .ForMember(dest => dest.LeaveTypeName, opt => opt.MapFrom(src => src.LeaveType.Name));

            #endregion

        }
    }
}
