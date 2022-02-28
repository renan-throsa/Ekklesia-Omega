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
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity<ObjectId>
    {
        private ApplicationContext Context { get; }
        private readonly string Entity = $"c_{typeof(T).Name.ToLower()}";

        private IMongoCollection<T> _entities;

        public IMongoCollection<T> Entities
        {
            get { return _entities ?? (_entities = GetOrCreateEntity()); }
        }

        public Repository(ApplicationContext context)
        {
            Context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await Entities.InsertOneAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities)
        {
            await Entities.InsertManyAsync(entities);
            return entities;
        }

        public async Task<IEnumerable<T>> AllAsync()
        {
            var filter = Builders<T>.Filter.Empty;
            return await Entities.Find(filter).ToListAsync();
        }       

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter)
        {
            var query = await Entities.FindAsync(filter);
            return query.ToEnumerable();
        }

        public async Task<T> FindSync(string Id)
        {
            if (ObjectId.TryParse(Id, out var _))
            {
                return await FindSync(ObjectId.Parse(Id));
            }
            throw new ArgumentException($"O Id fornecido não é válido. Id = {Id}");
        }

        public async Task<T> FindSync(ObjectId key)
        {
            var query = await Entities.FindAsync(x => x.Id == key);
            return await query.FirstOrDefaultAsync();
        }

        public Task<T> DeleteAsync(T entity)
        {
            return DeleteAsync(entity.Id);
        }

        public async Task DeleteAsync(string key)
        {
            await DeleteAsync(ObjectId.Parse(key));
        }

        public async Task<T> DeleteAsync(ObjectId Id)
        {
            T m = await FindSync(Id);
            if (m != null)
            {
                await Entities.DeleteOneAsync(x => x.Id == Id);
            }
            return m;
        }

        public async Task<IEnumerable<T>> DeleteAsync(IEnumerable<T> entities)
        {
            foreach (var ent in entities)
            {
                var idObjeto = ent.Id;
                await Entities.DeleteManyAsync(x => x.Id == idObjeto);
            }
            return entities;
        }

        public async Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entities)
        {
            foreach (var ent in entities)
            {
                await UpdateAsync(ent);
            }
            return entities;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Entities.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity);
            return entity;
        }

        public IMongoQueryable<T> GetQueryable()
        {
            return Entities.AsQueryable();
        }

        private IMongoCollection<T> GetOrCreateEntity()
        {
            if (Context.DataBase.GetCollection<T>(Entity) == null)
            {
                return CreateEntity();
            }
            return Context.DataBase.GetCollection<T>(Entity);
        }

        private IMongoCollection<T> CreateEntity()
        {
            Context.DataBase.CreateCollection(Entity);
            return Context.DataBase.GetCollection<T>(Entity);
        }



    }
}
