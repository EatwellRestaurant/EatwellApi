using Core.Entities.Abstract;
using Entities.Dtos.Permission;
using Entities.Dtos.ShiftDay;
using Entities.Enums.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Employee
{
    public class EmployeeDetailDto : IDto
    {
        public string? ImagePath { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string BranchName { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime? LeaveDate { get; set; }

        public decimal Salary { get; set; }

        public DateTime BirthDate { get; set; }

        public string NationalId { get; set; }

        public string Gender { get; set; }

        public string? MilitaryStatus { get; set; }

        public string MaritalStatus { get; set; }

        public string Address { get; set; }

        public string PositionName { get; set; }

        public string PositionDisplayName { get; set; }

        public string EmploymentType { get; set; }
         
        public string EducationLevel { get; set; }

        public string WorkStatusName { get; set; }

        public string WorkStatusDisplayName { get; set; }

        public string ExperienceDuration { get; set; }

        public string Manager { get; set; }

        public List<ShiftDayDto> ShiftDayDtos { get; set; }

        public List<PermissionListDto> PermissionListDtos { get; set; }

    }
}
