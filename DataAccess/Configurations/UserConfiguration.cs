using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(50);
            builder.Property(u => u.LastName).HasMaxLength(50);
            builder.Property(u => u.Email).HasMaxLength(254);
            builder.Property(u => u.VerificationCode).HasMaxLength(5);
            builder.Property(u => u.OperationClaimId).HasDefaultValue(2);
            builder.Property(u => u.IsDeleted).HasDefaultValue(false);

            builder.HasOne(u => u.OperationClaim).WithMany(o => o.Users).HasForeignKey(o => o.OperationClaimId);

            builder.HasData(
                new User() { Id = 1, Email = "eatwelladmin@gmail.com", Password = "$2a$11$o8NFTDWpruBKmi7b21tjve3gekmLul5lQn58kSI3E5qNg5q0BnmoG", FirstName = "Süper", LastName = "Admin", OperationClaimId = 1 });
        }

    }
}
