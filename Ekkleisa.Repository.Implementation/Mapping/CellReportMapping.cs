using Ekklesia.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ekkleisa.Repository.Implementation.Mapping
{
    public class CellReportMapping : IEntityTypeConfiguration<CellReport>
    {
        public void Configure(EntityTypeBuilder<CellReport> builder)
        {
            builder.ToTable("CellReport");
        }
    }
}
