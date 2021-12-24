using Ekklesia.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ekkleisa.Repository.Implementation.Mapping
{
    public class AtypicalMapping : IEntityTypeConfiguration<Atypical>
    {
        public void Configure(EntityTypeBuilder<Atypical> builder)
        {
            builder.ToTable("Atypical");

            builder.Property(a => a.Description).HasMaxLength(200).IsRequired();
        }
    }
}
