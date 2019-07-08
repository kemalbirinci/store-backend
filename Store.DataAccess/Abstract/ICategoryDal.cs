using Store.Core.DataAccess;
using Store.Entities.Concrete;

namespace Store.DataAccess.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
    }
}
