using Ekklesia.Domain.Entities;
using Ekklesia.Domain.Filters;

namespace Ekklesia.Application.Infrastructure
{
    public interface IReportRepository : IRepository<Report>
    {
        IEnumerable<Report> Browse(ReportFilterParams filter);
    }
}
