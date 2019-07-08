using System.Collections.Generic;
using Store.Business.Abstract;
using Store.DataAccess.Abstract;
using Store.Entities.Concrete;

namespace Store.Business.Concrete.Managers
{
    public class CategoryManager : ICategoryService
    {
       private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category Add(Category entity)
        {
            return _categoryDal.Add(entity);
        }

        public int Delete(Category entity)
        {
            return _categoryDal.Delete(entity);
        }

        public int Delete(int id)
        {
            return _categoryDal.Delete(_categoryDal.Get(x => x.CategoryID == id));
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x=>x.CategoryID==id);
        }

        public Category Update(Category entity)
        {
            return _categoryDal.Update(entity);
        }
    }
}
