using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transformers.Bank.Entities;

namespace Transformers.Bank.Data.Respositories
{
    public class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        protected DbSet<TEntity> DbSet { get; }

        public BaseRepository(DbSet<TEntity> dbSet)
        {
            DbSet = dbSet;
        }

        public TEntity Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TKey id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
