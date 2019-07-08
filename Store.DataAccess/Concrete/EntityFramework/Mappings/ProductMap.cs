using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Store.Entities.Concrete;

namespace Store.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Products");
            HasKey(x => x.ProductID);

            Property(x => x.ProductID).HasColumnName("ProductID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CategoryID).HasColumnName("CategoryID").IsRequired().HasColumnType("int");
            Property(x => x.ProductName).HasColumnName("ProductName").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.Price).HasColumnName("Price").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.PriceVat).HasColumnName("PriceVat").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.UnitInStock).HasColumnName("UnitInStock").IsRequired().HasColumnType("int");

            HasRequired(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryID).WillCascadeOnDelete(false);
        }
    }
}
