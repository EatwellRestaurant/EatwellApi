using EatwellApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatwellApi.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(250);
            builder.Property(p => p.IsActive).HasDefaultValue(true);


            builder.HasOne(p => p.MealCategory).WithMany(m => m.Products).HasForeignKey(p => p.MealCategoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
