
using Ekkleisa.Infrastructure.Context;
using Ekklesia.Application.Infrastructure;
using Ekklesia.Domain.Entities;
using Ekklesia.Domain.Filters;

namespace Ekkleisa.Infrastructure.Repositories
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
