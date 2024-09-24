using Ekklesia.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace Ekklesia.Application.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task AddAsync(TEntity entity);
        Task AddAsync(IEnumerable<TEntity> entities);
        Task<TEntity> FindAsync(ObjectId key);
        Task<TEntity> FindAsync(string Id);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter);        
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(string Id);
        Task<DeleteResult> DeleteAsync(ObjectId Id);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> All(Expression<Func<TEntity, TEntity>> projection);
        IMongoQueryable<TEntity> GetQueryable();

    }
}
