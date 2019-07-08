using Store.Core.Entities;

namespace Store.Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public int UnitInStock { get; set; }
        public decimal Price { get; set; }
        public decimal PriceVat { get; set; }

        public virtual Category Category { get; set; }
    }
}
