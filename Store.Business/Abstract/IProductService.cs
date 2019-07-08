using System.Collections.Generic;
using Store.Dtos.Concrete;
using Store.Entities.Concrete;

namespace Store.Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        Product GetByIdWithCategory(int id);
        List<Product> GetAllWithCategory();
    }
}
