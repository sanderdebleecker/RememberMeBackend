using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace RememberMeBackend.Data.Repositories {
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class {

        protected readonly DbContext Context;

        public GenericRepository(DbContext context) {
            this.Context = context;
        }

        public TEntity Get(string uuid) {
            return Context.Set<TEntity>().Find(uuid);
        }

        public IEnumerable<TEntity> GetAll() {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) {
            return Context.Set<TEntity>().Where(predicate);
        }

        public void Add(TEntity entity) {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities) {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity) {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities) {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}