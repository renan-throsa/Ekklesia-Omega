using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ekkleisa.Repository.Contract.IRepositories
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities);
        Task<T> FindSync(ObjectId key);
        Task<T> FindSync(string Id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> AllAsync();
        Task<T> DeleteAsync(T entity);
        Task DeleteAsync(string Id);
        Task<T> DeleteAsync(ObjectId Id);
        Task<T> UpdateAsync(T entity);
        Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entities);
        IMongoQueryable<T> GetQueryable();

    }
}
