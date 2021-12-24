using Ekklesia.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ekkleisa.Repository.Implementation.Mapping
{
    public class CellMapping : IEntityTypeConfiguration<Cell>
    {
        public void Configure(EntityTypeBuilder<Cell> builder)
        {
            builder.ToTable("Cell");
        }
    }
}
