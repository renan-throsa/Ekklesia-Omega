using Ekklesia.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Ekkleisa.Repository.Implementation.Mapping
{
    public class GroupReportMapping : IEntityTypeConfiguration<GroupReport>
    {
        public void Configure(EntityTypeBuilder<GroupReport> builder)
        {
            builder.ToTable("GroupReport");
        }
    }
}
