using Core.Entities.Abstract;
using Entities.Enums.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Employee : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int BranchId { get; set; }

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

        public string? ImagePath { get; set; }

        public string? ImageName { get; set; }







        public User User { get; set; }

        public Branch Branch { get; set; }

        public City City { get; set; }

        public ICollection<ShiftDay> ShiftDays { get; set; }

    }
}
