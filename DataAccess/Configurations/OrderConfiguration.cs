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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.Branch).WithMany(b => b.Orders).HasForeignKey(o => o.BranchId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(o => o.Table).WithMany(t => t.Orders).HasForeignKey(o => o.TableId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(o => o.Reservation).WithOne(r => r.Order).HasForeignKey<Order>(o => o.ReservationId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
