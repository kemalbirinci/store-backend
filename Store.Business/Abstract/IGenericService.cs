using System.Collections.Generic;
using Store.Core.Entities;

namespace Store.Business.Abstract
{
    public interface IGenericService<T> where T : class, IEntity
    {
        T GetById(int id);
        List<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        int Delete(T entity);
        int Delete(int id);
    }
}
