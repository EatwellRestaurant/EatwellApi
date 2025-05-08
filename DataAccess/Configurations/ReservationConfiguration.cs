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
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(r => r.FullName).HasMaxLength(85);
            builder.Property(r => r.Email).HasMaxLength(254);
            builder.Property(r => r.Phone).HasMaxLength(14);

            builder.HasOne(r => r.Branch).WithMany(b => b.Reservations).HasForeignKey(r => r.BranchId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(r => r.Table).WithMany(b => b.Reservations).HasForeignKey(r => r.TableId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
