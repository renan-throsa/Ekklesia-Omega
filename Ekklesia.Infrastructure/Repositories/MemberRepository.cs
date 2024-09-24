using Ekkleisa.Infrastructure.Context;
using Ekklesia.Application.Infrastructure;
using Ekklesia.Domain.Entities;
using Ekklesia.Domain.Filters;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ekkleisa.Infrastructure.Repositories
{
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {

        public MemberRepository(ApplicationContext context)
            : base(context)
        {

        }

        public IEnumerable<Member> Browse(MemberFilterParams filter)
        {
            IQueryable<Member> query = GetQueryable();


            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    Expression<Func<Member, bool>> propName = (x) => x.Name.Contains(filter.Name);
                    query = query.Where(propName);
                }
                if (filter.Role != null)
                {
                    Expression<Func<Member, bool>> propRole = x => x.Role == filter.Role;
                    query = query.Where(propRole);
                }
                if (filter.Before != null)
                {
                    Expression<Func<Member, bool>> propRole = x => x.BirthDay <= filter.Before;
                    query = query.Where(propRole);
                }
                if (filter.After != null)
                {
                    Expression<Func<Member, bool>> propRole = x => x.BirthDay >= filter.After;
                    query = query.Where(propRole);
                }
            }

            return query.AsNoTracking();
        }

    }
}
