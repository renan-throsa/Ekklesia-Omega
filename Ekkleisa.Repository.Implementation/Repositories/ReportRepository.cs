using Ekkleisa.Repository.Contract.IRepositories;
using Ekkleisa.Repository.Implementation.Context;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Filters;
using System.Collections.Generic;
using System.Linq;

namespace Ekkleisa.Repository.Implementation.Repositories
{
    public class ReportRepository : BaseRepository<Report>, IReportRepository
    {
        public ReportRepository(ApplicationContext context)
            : base(context)
        {

        }
        public IEnumerable<Report> Browse(ReportFilterParams filter)
        {
            IQueryable<Report> query = GetQueryable();

            query = query.OrderByDescending(x => x.Date);
            return query.ToList();
        }
    }
}
