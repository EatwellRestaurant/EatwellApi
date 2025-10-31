using EatwellApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatwellApi.Persistence.Configurations
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.Property(l => l.Name).HasMaxLength(200);

            builder.HasData(
                new LeaveType() { Id = 1, Name = "Yıllık İzin" },
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
