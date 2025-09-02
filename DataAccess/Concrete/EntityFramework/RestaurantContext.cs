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



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
