using Ekklesia.Domain.Entities;
using Ekklesia.Domain.Filters;

namespace Ekklesia.Application.Infrastructure
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        IEnumerable<Transaction> Browse(TransactionFilterParams filter);
    }
}
