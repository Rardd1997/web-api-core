using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace STOP.NET.REST.Data.Repository
{
    public interface IDataRepository<TEntity>
    {
        IQueryable<TEntity> FindAll();
        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> LookupAsync(string id);
        TEntity Lookup(string id);
        Task InsertAsync(TEntity entity);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Upsert(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
