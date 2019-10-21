using Microsoft.EntityFrameworkCore;
using STOP.NET.REST.Data.Context;
using STOP.NET.REST.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace STOP.NET.REST.Data.Repository
{
    public abstract class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : BaseModel
    {
        private readonly RESTContext _Context;

        public DataRepository(RESTContext context)
        {
            _Context = context;
        }

        public IQueryable<TEntity> FindAll()
        {
            return _Context.Set<TEntity>().AsNoTracking();
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _Context.Set<TEntity>().Where(expression).AsNoTracking();
        }

        public async Task InsertAsync(TEntity entity)
        {
            if (string.IsNullOrEmpty(entity.Id))
                entity.Id = Guid.NewGuid().ToString();

            await _Context.Set<TEntity>().AddAsync(entity);
        }

        public void Insert(TEntity entity)
        {
            if (string.IsNullOrEmpty(entity.Id))
                entity.Id = Guid.NewGuid().ToString();

            _Context.Set<TEntity>().Add(entity);
        }

        public async Task<TEntity> LookupAsync(string id)
        {
            var entity = await _Context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefaultAsync();
            return entity;
        }

        public TEntity Lookup(string id)
        {
            return _Context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefault();
        }

        public void Update(TEntity entity)
        {
            _Context.Set<TEntity>().Update(entity);
        }

        public void Upsert(TEntity entity)
        {
            if(string.IsNullOrEmpty(entity.Id))
                _Context.Set<TEntity>().Add(entity);
            else
                _Context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _Context.Set<TEntity>().Remove(entity);
        }

        public void SaveChanges()
        {
            _Context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _Context.SaveChangesAsync();
        }
    }
}
