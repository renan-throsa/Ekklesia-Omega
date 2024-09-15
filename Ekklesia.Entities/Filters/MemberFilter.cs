using Ekklesia.Entities.Entities;
using System.Linq;

namespace Ekklesia.Entities.Filters
{
    public class MemberFilter : BaseFilter<Member>
    {
        public MemberFilter(IQueryable<Member> query, BaseFilterParams baseFilterParams) : base(query, baseFilterParams) { }

    }
}
