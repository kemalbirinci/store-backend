using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Store.Entities.Concrete;

namespace Store.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CategoryMap:EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable("Categories");
            HasKey(x=>x.CategoryID);

            Property(x => x.CategoryID).HasColumnName("CategoryID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CategoryName).HasColumnName("CategoryName").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired().HasColumnType("bit");
            Property(x => x.Order).HasColumnName("Order").IsRequired().HasColumnType("int");
        }
    }
}
