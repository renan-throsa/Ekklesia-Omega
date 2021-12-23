using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekkleisa.Repository.Contract.IRepositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        IEnumerable<Transaction> Browse(TransactionFilter filter);
    }
}
