using Ekkleisa.Repository.Contract.IRepositories;
using Ekkleisa.Repository.Implementation.Context;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ekkleisa.Repository.Implementation.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationContext context) 
            : base(context)
        {

        }

        public IEnumerable<Transaction> Browse(TransactionFilter filter)
        {
            IQueryable<Transaction> query = GetQueryable();

            if (filter != null)
            {
                if (filter.DiscountBiggerThan != 0)
                {
                    query = query.Where(p => filter.DiscountBiggerThan > p.Value);
                }

                if (filter.DiscountLessThan != 0)
                {
                    query = query.Where(p => filter.DiscountLessThan < p.Value);
                }

                if (filter.Before != null)
                {
                    query = query.Where(o => filter.Before > o.Date);
                }

                if (filter.After != null)
                {
                    query = query.Where(o => o.Date > filter.After);
                }

            }
            query = query.OrderByDescending(x => x.Value);
            return query.ToList();
        }
    }
}
