using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Filters;
using System.Collections.Generic;

namespace Ekkleisa.Repository.Contract.IRepositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        IEnumerable<Transaction> Browse(TransactionFilter filter);
    }
}
