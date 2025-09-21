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
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.Property(l => l.Name).HasMaxLength(200);

            builder.HasData(
                new LeaveType() { Id = 1, Name = "Yıllık İzin"},
                new LeaveType() { Id = 2, Name = "Mazeret İzni" },
                new LeaveType() { Id = 3, Name = "Ücretsiz İzin" },
                new LeaveType() { Id = 4, Name = "Hastalık İzni" },
                new LeaveType() { Id = 5, Name = "Doğum İzni" },
                new LeaveType() { Id = 6, Name = "Babalık İzni" },
                new LeaveType() { Id = 7, Name = "Evlilik İzni" },
                new LeaveType() { Id = 8, Name = "Cenaze İzni" });
        }
    }
}
