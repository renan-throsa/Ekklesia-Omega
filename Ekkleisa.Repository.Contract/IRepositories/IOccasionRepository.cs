using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Filters;
using System.Collections.Generic;

namespace Ekkleisa.Repository.Contract.IRepositories
{
    public interface IOccasionRepository : IRepository<Occasion>
    {
        IEnumerable<Occasion> Browse(OccasionFilterParams filter);
    }
}
