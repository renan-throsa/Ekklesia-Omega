using Ekklesia.Domain.Entities;
using System.Linq;

namespace Ekklesia.Domain.Filters
{
    public class MemberFilter : BaseFilter<Member>
    {
        public MemberFilter(IQueryable<Member> query, BaseFilterParams baseFilterParams) : base(query, baseFilterParams) { }

    }
}
