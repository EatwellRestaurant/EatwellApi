using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.HasData(
                new OperationClaim { Id = 1, Name = "Admin" },
                new OperationClaim { Id = 2, Name = "User" },
                new OperationClaim { Id = 3, Name = "Manager" },
                new OperationClaim { Id = 4, Name = "Chef" },
                new OperationClaim { Id = 5, Name = "Waiter" },
                new OperationClaim { Id = 6, Name = "Delivery" },
                new OperationClaim { Id = 7, Name = "Cashier" });
        }
    }
}
