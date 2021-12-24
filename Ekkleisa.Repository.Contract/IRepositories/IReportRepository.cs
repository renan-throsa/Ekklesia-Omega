using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Filters;
using System.Collections.Generic;

namespace Ekkleisa.Repository.Contract.IRepositories
{
    public interface IReportRepository : IRepository<Report>
    {
        IEnumerable<Report> Browse(ReportFilter filter);
    }
}
