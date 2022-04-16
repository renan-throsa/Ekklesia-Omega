using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Ekkleisa.Repository.Implementation.Mapping
{
    public class ReunionMapping : IEntityTypeConfiguration<Reunion>
    {
        public void Configure(EntityTypeBuilder<Reunion> builder)
        {
            builder.ToTable("Reunion");

            builder.Property(r => r.Topic).HasMaxLength(200).IsRequired();

            builder.Property(r => r.EndTime)
                .HasColumnType("datetime")
               .HasDefaultValueSql("getdate()");

            builder.Property(r => r.ReunionType)
                .HasMaxLength(20)
                .IsRequired()
                .HasConversion<string>(e => e.ToString(), e => (ReunionType)Enum.Parse(typeof(ReunionType), e)
                );

            builder.HasMany(r => r.Participants);
        }
    }
}
