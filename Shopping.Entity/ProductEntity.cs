using Newtonsoft.Json;
using Shopping.Shared;

namespace Shopping.Entity
{
    public class ProductEntity : CosmosBaseEntity
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "category")]
        public ProductCategory Category { get; set; }
        [JsonProperty(PropertyName = "inStock")]
        public bool InStock { get; set; }
    }
}
