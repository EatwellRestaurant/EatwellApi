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
    public class EvaluationConfiguration : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.HasOne(e => e.User).WithMany(u => u.Evaluations).HasForeignKey(e => e.UserId);
        }
    }
}
