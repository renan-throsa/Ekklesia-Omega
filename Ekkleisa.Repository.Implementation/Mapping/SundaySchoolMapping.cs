using Ekklesia.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ekkleisa.Repository.Implementation.Mapping
{
    public class SundaySchoolMapping : IEntityTypeConfiguration<SundaySchool>
    {
        public void Configure(EntityTypeBuilder<SundaySchool> builder)
        {
            builder.ToTable("SundaySchool");

            builder.Property(ss => ss.Theme).HasMaxLength(200).IsRequired();
            builder.Property(ss => ss.Verse).HasMaxLength(200).IsRequired();

        }
    }
}
