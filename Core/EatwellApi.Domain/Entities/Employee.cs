using EatwellApi.Domain.Entities.Abstract;
using EatwellApi.Domain.Enums.Employee;

namespace EatwellApi.Domain.Entities
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

        public string? ImagePath { get; set; }

        public string? ImageName { get; set; }







        public User User { get; set; }

        public Branch Branch { get; set; }

        public City City { get; set; }

        public ICollection<ShiftDay> ShiftDays { get; set; }
        public ICollection<Permission> Permissions { get; set; }
        public ICollection<EmployeeSalary> EmployeeSalaries { get; set; }
        public ICollection<EmployeeBonus> EmployeeBonuses { get; set; }
        public ICollection<EmployeeDeduction> EmployeeDeductions { get; set; }

        // Bu çalışana atanan görevler
        public ICollection<EmployeeTask> AssignedTasks { get; set; }

        // Bu çalışanın başkalarına atadığı görevler
        public ICollection<EmployeeTask> CreatedTasks { get; set; }

        public ICollection<EmployeeTaskComment> EmployeeTaskComments { get; set; }


    }
}
