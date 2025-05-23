﻿using Entities.Concrete;
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

            builder.HasOne(u => u.OperationClaim).WithMany(o => o.Users).HasForeignKey(o => o.OperationClaimId);
        }
    }
}
