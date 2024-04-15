using Ekkleisa.Repository.Contract.IRepositories;
using Ekkleisa.Repository.Implementation.Context;
using Ekklesia.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ekkleisa.Repository.Implementation.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        private ApplicationContext Context { get; }
        private readonly string Entity = $"c_{typeof(TEntity).Name.ToLower()}";

        private IMongoCollection<TEntity> _entities;

        protected IMongoCollection<TEntity> Entities
        {
            get { return _entities ?? (_entities = GetOrCreateEntity()); }
        }

        public BaseRepository(ApplicationContext context)
        {
            Context = context;
        }

        public Task AddAsync(TEntity entity)
        {
            return Entities.InsertOneAsync(entity);
        }

        public Task AddAsync(IEnumerable<TEntity> entities)
        {
            return Entities.InsertManyAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> AllAsync()
        {
            var filter = Builders<TEntity>.Filter.Empty;
            var query = await Entities.FindAsync(filter);
            return query.ToEnumerable();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter)
        {
            var query = await Entities.FindAsync(filter);
            return query.ToEnumerable();
        }

        public async Task<TEntity> FindSync(string Id)
        {
            return await FindSync(ObjectId.Parse(Id));
        }

        public async Task<TEntity> FindSync(ObjectId key)
        {
            var query = await Entities.FindAsync(x => x.Id == key);
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
            TEntity m = await FindSync(Id);
            if (m != null)
            {
                return await Entities.DeleteOneAsync(x => x.Id == Id);
            }
            return null;
        }

        public async Task<IEnumerable<TEntity>> DeleteAsync(IEnumerable<TEntity> entities)
        {
            foreach (var ent in entities)
            {
                var idObjeto = ent.Id;
                await Entities.DeleteManyAsync(x => x.Id == idObjeto);
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
            return Entities.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity);
        }

        public IMongoQueryable<TEntity> GetQueryable()
        {
            return Entities.AsQueryable();
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
