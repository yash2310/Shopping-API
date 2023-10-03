using Shopping.Shared;

namespace Shopping.Entity
{
    public class ProductEntity : NoSQLBaseEntity
    {
        public int ProductId { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ProductCategory Category { get; set; }
        public bool InStock { get; set; }
    }
}
