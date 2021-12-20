using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekkleisa.Repository.Contract.IRepositories
{
    public interface IRepository<T>
    {
        Task<T> Add(T entity);
        Task<IEnumerable<T>> All();
        Task<IEnumerable<T>> BulkAdd(IEnumerable<T> entities);
        Task<IEnumerable<T>> BulkAddAsync(IEnumerable<T> entities);
        Task<IEnumerable<T>> BulkDelete(IEnumerable<T> entities);
        Task<IEnumerable<T>> BulkDelete(IEnumerable<object> ids);
        Task<IEnumerable<T>> BulkDeleteAsync(IEnumerable<T> entities);
        Task<IEnumerable<T>> BulkDeleteAsync(IEnumerable<object> ids);
        Task<IEnumerable<T>> BulkUpdate(IEnumerable<T> entities);
        Task<IEnumerable<T>> BulkUpdateAsync(IEnumerable<T> entities);
        Task<T> Delete(T entity);
        Task<T> Delete(object id);
        Task<T> GetById(object id);
        IQueryable<T> GetQueryable();
        Task<T> Update(T entity);
    }
}
