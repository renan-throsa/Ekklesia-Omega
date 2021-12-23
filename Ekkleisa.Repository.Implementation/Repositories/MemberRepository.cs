using Ekkleisa.Repository.Contract.IRepositories;
using Ekkleisa.Repository.Implementation.Context;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Filters;
using System.Collections.Generic;
using System.Linq;

namespace Ekkleisa.Repository.Implementation.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        
        public MemberRepository(EkklesiaContext context)
            : base(context, context.Members)
        {
            
        }

        public IEnumerable<Member> Browse(MemberFilter filter)
        {
            IQueryable<Member> query = GetQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    query = query.Where(p => p.Name.Contains(filter.Name));
                }
                if (filter.Role != null)
                {
                    query = query.Where(c => c.Role == filter.Role);
                }

            }
            query = query.OrderByDescending(x => x.Name);
            return query.ToList();
        }
        
    }
}
