using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Filters;
using System.Collections.Generic;

namespace Ekkleisa.Repository.Contract.IRepositories
{
    public interface IMemberRepository : IRepository<Member>
    {
        IEnumerable<Member> Browse(MemberFilter filter);        
    }
}
