using System.Collections.Generic;
using Store.Business.Abstract;
using Store.DataAccess.Abstract;
using Store.Dtos.Concrete;
using Store.Entities.Concrete;
using System.Linq;

namespace Store.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public Product Add(Product entity)
        {
            return _productDal.Add(entity);
        }

        public int Delete(Product entity)
        {
            return _productDal.Delete(entity);
        }

        public int Delete(int id)
        {
            return _productDal.Delete(_productDal.Get(x => x.ProductID == id));
        }

        public Product GetById(int id)
        {
            return _productDal.Get(x => x.ProductID == id);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetByIdWithCategory(int id)
        {
            return _productDal.FindByIdWithCategory(id);
        }

        public List<Product> GetAllWithCategory()
        {
            return _productDal.GetListWithCategory(null);
        }

        public Product Update(Product entity)
        {
            return _productDal.Update(entity);
        }
    }
}
