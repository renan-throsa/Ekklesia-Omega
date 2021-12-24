using Ekklesia.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ekkleisa.Repository.Implementation.Mapping
{
    public class OccasionMapping : IEntityTypeConfiguration<Occasion>
    {
        public void Configure(EntityTypeBuilder<Occasion> builder)
        {
            builder.ToTable("Occasion");
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Date)
                .HasColumnType("datetime")
               .HasDefaultValueSql("getdate()");
        }
    }
}
