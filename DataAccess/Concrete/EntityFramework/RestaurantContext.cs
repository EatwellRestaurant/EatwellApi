using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DataAccess.Concrete.EntityFramework
{
    public class RestaurantContext : DbContext
    {

        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }



        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchImage> BranchImages { get; set; }
        public DbSet<BranchEmployee> BranchEmployees { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<MealCategory> MealCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<PageContent> PageContents { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<HeadOffice> HeadOffices { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ShiftDay> ShiftDays { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<LeaveRight> LeaveRights { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; } 
        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        public DbSet<EmployeeBonus> EmployeeBonuses { get; set; }
        public DbSet<EmployeeDeduction> EmployeeDeductions { get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public DbSet<EmployeeSubTask> EmployeeSubTasks { get; set; }
        public DbSet<EmployeeTaskComment> EmployeeTaskComments { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
