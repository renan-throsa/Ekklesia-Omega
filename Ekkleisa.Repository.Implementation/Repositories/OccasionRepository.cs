using Ekkleisa.Repository.Contract.IRepositories;
using Ekkleisa.Repository.Implementation.Context;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Filters;
using System.Collections.Generic;
using System.Linq;

namespace Ekkleisa.Repository.Implementation.Repositories
{
    public class OccasionRepository : BaseRepository<Occasion>, IOccasionRepository
    {
        public OccasionRepository(ApplicationContext context)
            : base(context)
        {

        }

        public IEnumerable<Occasion> Browse(OccasionFilter filter)
        {
            IQueryable<Occasion> query = GetQueryable();

            if (filter != null)
            {
                if (filter.Before != null)
                {
                    query = query.Where(o => filter.Before > o.StartTime);
                }

                if (filter.After != null)
                {
                    query = query.Where(o => o.StartTime > filter.After);
                }

            }
            query = query.OrderByDescending(x => x.StartTime);
            return query.ToList();
        }
    }
}
