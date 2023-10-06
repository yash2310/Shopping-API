namespace Shopping.Shared
{
    public class ProductDTO : CommonDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public ProductCategory Category { get; set; }
        public bool InStock { get; set; }
    }
}
