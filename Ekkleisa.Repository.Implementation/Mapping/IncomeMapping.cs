using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekkleisa.Repository.Implementation.Mapping
{
    public class IncomeMapping : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder.ToTable("Income");
            builder.Property(i => i.Type)
                .HasMaxLength(20)
                .IsRequired()
                .HasConversion<string>(e => e.ToString(), e => (RevenueType)Enum.Parse(typeof(RevenueType), e)
                );
        }
    }
}
