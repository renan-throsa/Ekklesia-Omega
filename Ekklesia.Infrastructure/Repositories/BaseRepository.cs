using Ekkleisa.Infrastructure.Context;
using Ekklesia.Application.Infrastructure;
using Ekklesia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace Ekkleisa.Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        private ApplicationContext Context { get; }

        private readonly string Entity = $"c_{typeof(TEntity).Name.ToLower()}";

        private IMongoCollection<TEntity> _entities;

        protected IMongoCollection<TEntity> Domain
        {
            get { return _entities ?? (_entities = GetOrCreateEntity()); }
        }

        public BaseRepository(ApplicationContext context)
        {
            Context = context;
        }

        public Task AddAsync(TEntity entity)
        {
            return Domain.InsertOneAsync(entity);
        }

        public Task AddAsync(IEnumerable<TEntity> entities)
        {
            return Domain.InsertManyAsync(entities);
        }

        public IEnumerable<TEntity> All(Expression<Func<TEntity, TEntity>> projection)
        {
            return Domain.AsQueryable().Select(projection).AsEnumerable();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter)
        {
            var query = await Domain.FindAsync(filter);
            return query.ToEnumerable();
        }

        public async Task<TEntity> FindAsync(string Id)
        {
            return await FindAsync(ObjectId.Parse(Id));
        }

        public async Task<TEntity> FindAsync(ObjectId key)
        {
            var query = await Domain.FindAsync(x => x.Id == key);
            return await query.FirstOrDefaultAsync();
        }

        public Task DeleteAsync(TEntity entity)
        {
            return DeleteAsync(entity.Id);
        }

        public Task DeleteAsync(string key)
        {
            return DeleteAsync(ObjectId.Parse(key));
        }

        public async Task<DeleteResult> DeleteAsync(ObjectId Id)
        {
            TEntity m = await FindAsync(Id);
            if (m != null)
            {
                return await Domain.DeleteOneAsync(x => x.Id == Id);
            }
            return null;
        }

        public async Task<IEnumerable<TEntity>> DeleteAsync(IEnumerable<TEntity> entities)
        {
            foreach (var ent in entities)
            {
                var idObjeto = ent.Id;
                await Domain.DeleteManyAsync(x => x.Id == idObjeto);
            }
            return entities;
        }

        public async Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities)
        {
            foreach (var ent in entities)
            {
                await UpdateAsync(ent);
            }
            return entities;
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Domain.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity);
        }

        public IMongoQueryable<TEntity> GetQueryable()
        {
            return Domain.AsQueryable();
        }

        private IMongoCollection<TEntity> GetOrCreateEntity()
        {
            if (Context.DataBase.GetCollection<TEntity>(Entity) == null)
            {
                return CreateEntity();
            }
            return Context.DataBase.GetCollection<TEntity>(Entity);
        }

        private IMongoCollection<TEntity> CreateEntity()
        {
            Context.DataBase.CreateCollection(Entity);
            return Context.DataBase.GetCollection<TEntity>(Entity);
        }

    }
}
