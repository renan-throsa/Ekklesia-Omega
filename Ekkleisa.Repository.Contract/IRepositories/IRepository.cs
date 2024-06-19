using Ekklesia.Entities.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ekkleisa.Repository.Contract.IRepositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task AddAsync(TEntity entity);
        Task AddAsync(IEnumerable<TEntity> entities);
        Task<TEntity> FindSync(ObjectId key);
        Task<TEntity> FindSync(string Id);
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
