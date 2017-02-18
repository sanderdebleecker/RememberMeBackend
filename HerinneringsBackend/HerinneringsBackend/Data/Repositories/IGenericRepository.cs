using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RememberMeBackend.Data.Repositories {
    public interface IGenericRepository<TEntity> where TEntity : class {
        TEntity Get(string uuid);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
