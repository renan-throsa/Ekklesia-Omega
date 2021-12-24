using Ekklesia.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekkleisa.Repository.Implementation.Mapping
{
    public class OccasionMemberMapping : IEntityTypeConfiguration<OccasionMember>
    {
        public void Configure(EntityTypeBuilder<OccasionMember> builder)
        {
            builder.ToTable("OccasionMember");

            builder.HasKey(om => new { om.OccasionId, om.MemberId });
        }
    }
}
