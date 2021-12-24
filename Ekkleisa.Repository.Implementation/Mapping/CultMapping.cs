using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Ekkleisa.Repository.Implementation.Mapping
{
    public class CultMapping : IEntityTypeConfiguration<Cult>
    {
        public void Configure(EntityTypeBuilder<Cult> builder)
        {
            builder.ToTable("Cult");

            builder.Property(c => c.KeyVerse).HasMaxLength(200).IsRequired();

            builder.Property(c => c.CultType)
                .HasMaxLength(20)
                .IsRequired()
                .HasConversion<string>(e => e.ToString(), e => (CultType)Enum.Parse(typeof(CultType), e)
                );
        }
    }
}
