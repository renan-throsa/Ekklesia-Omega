using Ekklesia.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Ekkleisa.Repository.Implementation.Mapping
{
    internal class MemberMapping : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Member");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Phone).HasMaxLength(11);
            builder.Property(m => m.Photo).IsRequired(false);

            builder.Property(c => c.Role)
                .HasMaxLength(20)
                .IsRequired()
                .HasConversion<string>(e => e.ToString(), e => (Role)Enum.Parse(typeof(Role), e)
                );
        }
    }
}
