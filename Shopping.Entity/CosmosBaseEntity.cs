using Newtonsoft.Json;

namespace Shopping.Entity
{
    public class CosmosBaseEntity : CommonEntity
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
    }
}
