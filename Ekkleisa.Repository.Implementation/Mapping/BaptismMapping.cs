using Ekklesia.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ekkleisa.Repository.Implementation.Mapping
{
    public class BaptismMapping : IEntityTypeConfiguration<Baptism>
    {
        public void Configure(EntityTypeBuilder<Baptism> builder)
        {
            builder.ToTable("Baptism");

            builder.Property(b => b.Place).HasMaxLength(100).IsRequired();

            builder
            .HasMany(b => b.Baptizeds)
            .WithOne();
        }
    }
}
