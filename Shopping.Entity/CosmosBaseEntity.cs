using Newtonsoft.Json;

namespace Shopping.Entity
{
    public class CosmosBaseEntity
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [JsonProperty(PropertyName = "updatedBy")]
        public string UpdatedBy { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "updatedOn")]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
