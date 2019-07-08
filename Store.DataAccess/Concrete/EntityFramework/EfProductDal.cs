using System;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using Store.Core.DataAccess.EntityFramework;
using Store.DataAccess.Abstract;
using Store.Entities.Concrete;
using System.Collections.Generic;

namespace Store.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfRepositoryBase<Product, StoreContext>, IProductDal
    {
        public Product FindByIdWithCategory(int id)
        {
            using (var context = new StoreContext())
            {
                return context.Products.Include(x => x.Category).Where(x => x.ProductID == id).SingleOrDefault();
            }
        }

        public List<Product> GetListWithCategory(Expression<Func<Product, bool>> predicate = null)
        {
            using (var context = new StoreContext())
            {
                return predicate == null ?
                    context.Products.Include(x => x.Category).ToList()
                    : context.Products.Include(x => x.Category).Where(predicate).ToList();
            }
        }
    }
}
