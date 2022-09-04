using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Framework.DataAccess.Entities;
using WebApi.Framework.DependencyInjection;

namespace WebApi.Framework.DataAccess.Repositories.EntityFramework
{
    public abstract class EntityFrameworkRepositoryBase<T> : ScopedService where T : EntityBaseIncrementalId
    {
        private readonly DbContext _context;
        public readonly IDbConnection Connection;

        protected EntityFrameworkRepositoryBase(DbContext context)
        {
            _context = context;
            Connection = context.Database.GetDbConnection();
        }

        public virtual T? Get(int Id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == Id);
        }

        public virtual int CreateWithoutSave(T request)
        {
            var item = _context.Add(request);

            return item is not null ? item.Entity.Id : 0;
        }
        public virtual T? DeleteWithoutSave(int id)
        {
            var item = _context.Set<T>().Remove(Get(id)!);

            return item is not null ? item.Entity : null;
        }
        public virtual T? DeleteWithoutSave(T entity)
        {
            var item = _context.Set<T>().Remove(entity);

            return item is not null ? item.Entity : null;

        }
        public virtual bool UpdateWithoutSave(T entity)
        {
            var item = _context.Set<T>().Update(entity);

            return item is not null;
        }

        public virtual int Create(T request)
        {
            var item = _context.Add(request);

            SaveChanges();

            return item is not null ? item.Entity.Id : 0;
        }
        public virtual T? Delete(int id)
        {
            var item = _context.Set<T>().Remove(Get(id)!);

            SaveChanges();

            return item is not null ? item.Entity : null;
        }
        public virtual T? Delete(T entity)
        {
            var item = _context.Set<T>().Remove(entity);

            SaveChanges();

            return item is not null ? item.Entity : null;

        }
        public virtual bool Update(T entity)
        {
            var item = _context.Set<T>().Update(entity);

            SaveChanges();

            return item is not null;
        }
        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
