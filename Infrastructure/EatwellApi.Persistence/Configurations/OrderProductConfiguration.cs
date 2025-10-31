using EatwellApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatwellApi.Persistence.Configurations
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(b => new { b.OrderId, b.ProductId });


            builder.HasOne(o => o.Order).WithMany(o => o.OrderProducts).HasForeignKey(o => o.OrderId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(o => o.Product).WithMany(p => p.OrderProducts).HasForeignKey(o => o.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
