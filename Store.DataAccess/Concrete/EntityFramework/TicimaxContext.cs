using System.Data.Entity;
using Store.DataAccess.Concrete.EntityFramework.Mappings;
using Store.Entities.Concrete;

namespace Store.DataAccess.Concrete.EntityFramework
{
    public class StoreContext : DbContext
    {
        public StoreContext()
        {
            Database.SetInitializer<StoreContext>(null);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
