namespace Shopping.Shared
{
    public class ProductDTO : CommonDTO
    {
        public int ProductId { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ProductCategory Category { get; set; }
        public bool InStock { get; set; }
    }
}
