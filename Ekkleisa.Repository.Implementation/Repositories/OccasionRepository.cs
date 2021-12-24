using Ekkleisa.Repository.Contract.IRepositories;
using Ekkleisa.Repository.Implementation.Context;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Filters;
using System.Collections.Generic;
using System.Linq;

namespace Ekkleisa.Repository.Implementation.Repositories
{
    public class OccasionRepository : Repository<Occasion>, IOccasionRepository
    {
        public OccasionRepository(EkklesiaContext context)
            : base(context, context.Occasions)
        {

        }

        public IEnumerable<Occasion> Browse(OccasionFilter filter)
        {
            IQueryable<Occasion> query = GetQueryable();

            if (filter != null)
            {
                if (filter.Before != null)
                {
                    query = query.Where(o => filter.Before > o.Date);
                }

                if (filter.After != null)
                {
                    query = query.Where(o => o.Date > filter.After);
                }

            }
            query = query.OrderByDescending(x => x.Date);
            return query.ToList();
        }
    }
}
