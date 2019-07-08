using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Store.Core.Entities;

namespace Store.Core.DataAccess
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> predicate);
        List<T> GetList(Expression<Func<T, bool>> predicate = null);
        T Add(T entity);
        T Update(T entity);
        int Delete(T entity);
    }
}
