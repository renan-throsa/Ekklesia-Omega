using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekkleisa.Repository.Contract.IRepositories
{
    public interface IOccasionRepository : IRepository<Occasion>
    {
        IEnumerable<Occasion> Browse(OccasionFilter filter);
    }
}
