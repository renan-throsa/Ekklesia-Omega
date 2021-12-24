using Ekklesia.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ekkleisa.Repository.Implementation.Mapping
{
    public class BiblicalReportMpping : IEntityTypeConfiguration<BiblicalReport>
    {
        public void Configure(EntityTypeBuilder<BiblicalReport> builder)
        {
            builder.ToTable("BiblicalReport");
        }
    }
}
