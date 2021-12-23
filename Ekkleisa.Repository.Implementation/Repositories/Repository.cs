using Ekkleisa.Repository.Contract.IRepositories;
using Ekkleisa.Repository.Implementation.Context;
using Ekklesia.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekkleisa.Repository.Implementation.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity<int>
    {
        private EkklesiaContext Context { get; }
        private DbSet<T> Entities { get; }

        public Repository(EkklesiaContext context, DbSet<T> entities)
        {
            Context = context;
            Entities = entities;
        }

        public async Task<T> Add(T entity)
        {
            await Entities.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> All()
        {
            return await Entities.ToListAsync();
        }


        public async Task<IEnumerable<T>> BulkAdd(IEnumerable<T> entities)
        {
            await Entities.AddRangeAsync(entities);
            await Context.SaveChangesAsync();
            return entities;
        }

        public async Task<IEnumerable<T>> BulkDelete(IEnumerable<T> entities)
        {
            Entities.RemoveRange(entities);
            await Context.SaveChangesAsync();
            return entities;
        }

        public async Task<IEnumerable<T>> BulkUpdate(IEnumerable<T> entities)
        {
            Entities.UpdateRange(entities);
            await Context.SaveChangesAsync();
            return entities;
        }

        public Task<T> Delete(T entity)
        {
            return Delete(entity.Id);
        }

        public async Task<T> Delete(object id)
        {
            T m = await GetById(id);
            if (m != null)
            {
                Entities.Remove(m);
                await Context.SaveChangesAsync();
            }
            return m;
        }

        public async Task<T> GetById(object id)
        {
            return await Entities.FindAsync((int)id);
        }

        public IQueryable<T> GetQueryable()
        {
            return Entities;
        }

        public async Task<T> Update(T entity)
        {
            var m = Entities.Attach(entity);
            m.State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }


    }
}
