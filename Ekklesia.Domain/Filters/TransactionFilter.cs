using Ekklesia.Domain.Entities;
using System.Linq;

namespace Ekklesia.Domain.Filters
{
    public class TransactionFilter : BaseFilter<Transaction>
    {
        public TransactionFilter(IQueryable<Transaction> query, BaseFilterParams baseFilterParams) : base(query, baseFilterParams)
        {
        }
    }
}
