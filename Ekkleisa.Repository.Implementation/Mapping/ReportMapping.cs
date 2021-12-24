using Ekklesia.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ekkleisa.Repository.Implementation.Mapping
{
    public class ReportMapping : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Report");
            builder.HasKey(r => r.Id);

            builder.Property(o => o.Date)
                .HasColumnType("datetime")
               .HasDefaultValueSql("getdate()");

        }
    }
}
