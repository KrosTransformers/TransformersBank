using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Transformers.Bank.Entities;

namespace Transformers.Bank.Data.Respositories
{
    public class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        protected DbSet<TEntity> DbSet { get; }
        protected DbContext DbContext { get; }

        public BaseRepository(DbSet<TEntity> dbSet, DbContext dbContext)
        {
            DbSet = dbSet;
            DbContext = dbContext;
        }

        public TEntity Add(TEntity entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TKey id)
        {
            var dbentity = DbSet.Find(id);
            DbSet.Remove(dbentity);
        }

        public List<TEntity> GetAll()
        {
            return DbSet.AsQueryable().ToList();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsQueryable().Where(predicate).ToList();
        }

        public TEntity GetById(TKey id)
        {
            return DbSet.Find(id);
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null) return null;

            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            // **************************************************************************
            // According to the article on https://msdn.microsoft.com/en-us/data/jj592676
            // attaching is done automatically when `State` is changed to `Modified`
            // **************************************************************************
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }


            // changing state automatically attaches if `Detached`
            dbEntityEntry.State = EntityState.Modified;

            return entity;
        }
    }
}
