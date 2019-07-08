using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Store.Core.Entities;

namespace Store.Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(predicate);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null)
        {
            using (var context = new TContext())
            {
                return predicate == null ?
                   context.Set<TEntity>().ToList()
                   : context.Set<TEntity>().Where(predicate).ToList();
            }
        }

        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();

                return entity;
            }
        }
        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();

                return entity;
            }
        }

        public int Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                return context.SaveChanges();
            }
        }
    }
}
