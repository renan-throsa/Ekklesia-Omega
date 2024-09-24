using Ekkleisa.Infrastructure.Context;
using Ekklesia.Application.Infrastructure;
using Ekklesia.Domain.Entities;
using Ekklesia.Domain.Filters;

namespace Ekkleisa.Infrastructure.Repositories
{
    public class OccasionRepository : BaseRepository<Occasion>, IOccasionRepository
    {
        public OccasionRepository(ApplicationContext context)
            : base(context)
        {

        }

        public IEnumerable<Occasion> Browse(OccasionFilterParams filter)
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
