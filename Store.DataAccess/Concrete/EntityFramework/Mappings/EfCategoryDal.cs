using Store.Core.DataAccess.EntityFramework;
using Store.DataAccess.Abstract;
using Store.Entities.Concrete;

namespace Store.DataAccess.Concrete.EntityFramework.Mappings
{
    public class EfCategoryDal : EfRepositoryBase<Category, StoreContext>, ICategoryDal
    {
    }
}
