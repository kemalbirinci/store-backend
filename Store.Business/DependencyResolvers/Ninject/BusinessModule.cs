using Ninject.Modules;
using System.Data.Entity;
using Store.Business.Abstract;
using Store.Business.Concrete.Managers;
using Store.DataAccess.Abstract;
using Store.DataAccess.Concrete.EntityFramework;

namespace Store.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<DbContext>().To<StoreContext>();
        }
    }
}
