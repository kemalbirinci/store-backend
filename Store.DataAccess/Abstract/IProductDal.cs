using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Store.Core.DataAccess;
using Store.Entities.Concrete;

namespace Store.DataAccess.Abstract
{
    public interface IProductDal : IRepository<Product>
    {
        Product FindByIdWithCategory(int id);
        List<Product> GetListWithCategory(Expression<Func<Product, bool>> predicate);
    }
}
