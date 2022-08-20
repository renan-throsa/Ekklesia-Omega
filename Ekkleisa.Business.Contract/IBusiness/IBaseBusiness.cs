using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ekkleisa.Business.Contract.IBusiness
{
    public interface IBaseBusiness<TEntity, TObject> : IFilterBusiness<TEntity, TObject> where TEntity : IEntity where TObject : IObject<TEntity>
    {
        Task<Response> AddAsync(TObject tObject);
        Task AddAsync(IEnumerable<TObject> tObjects);
        Task<Response> FindSync(ObjectId key);
        Task<Response> FindSync(string Id);
        Task<IEnumerable<TObject>> FindAsync(Expression<Func<TObject, bool>> filter);
        Task<IEnumerable<TObject>> AllAsync();
        Task DeleteAsync(TObject tObject);
        Task DeleteAsync(string Id);
        Task<DeleteResult> DeleteAsync(ObjectId Id);
        Task<Response> UpdateAsync(TObject tObject);
        Task<IEnumerable<TObject>> UpdateAsync(IEnumerable<TObject> tObjects);

    }
}
