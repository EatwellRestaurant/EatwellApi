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
                new OperationClaim { Id = 1, Name = "Admin", DisplayName = "Admin" },
                new OperationClaim { Id = 2, Name = "User", DisplayName = "Kullanıcı" },
                new OperationClaim { Id = 3, Name = "Manager", DisplayName = "Müdür" },
                new OperationClaim { Id = 4, Name = "Chef", DisplayName = "Şef" },
                new OperationClaim { Id = 5, Name = "Waiter", DisplayName = "Garson" },
                new OperationClaim { Id = 6, Name = "Delivery", DisplayName = "Kurye" },
                new OperationClaim { Id = 7, Name = "Cashier", DisplayName = "Kasiyer" });
        }
    }
}
