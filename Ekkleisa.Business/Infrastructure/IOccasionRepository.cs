using Ekklesia.Domain.Entities;
using Ekklesia.Domain.Filters;

namespace Ekklesia.Application.Infrastructure
{
    public interface IOccasionRepository : IRepository<Occasion>
    {
        IEnumerable<Occasion> Browse(OccasionFilterParams filter);
    }
}
