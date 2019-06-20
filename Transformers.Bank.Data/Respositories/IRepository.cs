using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Transformers.Bank.Entities;

namespace Transformers.Bank.Data.Respositories
{
    public interface IRepository<TEntity, TKey>
        where TEntity: class, IEntity<TKey>
    {
        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        TEntity GetById(TKey id);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(TKey id);
    }
}
