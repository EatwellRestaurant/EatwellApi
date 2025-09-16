using Core.Entities.Abstract;
using Entities.Dtos.ShiftDay;
using Entities.Enums.Employee;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Employee
{
    public class EmployeeUpsertDto : IDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int OperationClaimId { get; set; }

        public int CityId { get; set; }

        public string NationalId { get; set; }

        public DateTime BirthDate { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public GenderType Gender { get; set; }

        public EducationLevelType EducationLevel { get; set; }

        public MilitaryStatus? MilitaryStatus { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime? LeaveDate { get; set; }

        public WorkStatusType WorkStatus { get; set; }

        public EmploymentType EmploymentType { get; set; }

        public decimal Salary { get; set; }

        public ICollection<ShiftDayDto> ShiftDayDtos { get; set; }
    }
}
