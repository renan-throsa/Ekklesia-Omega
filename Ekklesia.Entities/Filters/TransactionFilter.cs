using Ekklesia.Entities.Entities;
using System.Linq;

namespace Ekklesia.Entities.Filters
{
    public class TransactionFilter : BaseFilter<Transaction>
    {
        public TransactionFilter(IQueryable<Transaction> query, BaseFilterParams baseFilterParams) : base(query, baseFilterParams)
        {
        }
    }
}
