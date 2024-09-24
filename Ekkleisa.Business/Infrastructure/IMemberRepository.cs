using Ekklesia.Domain.Entities;
using Ekklesia.Domain.Filters;

namespace Ekklesia.Application.Infrastructure
{
    public interface IMemberRepository : IRepository<Member>
    {
        IEnumerable<Member> Browse(MemberFilterParams filter);          
    }
}
