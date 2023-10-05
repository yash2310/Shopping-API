using Newtonsoft.Json;
using Shopping.Shared.Enum;

namespace Shopping.Entity
{
    public class LogEntity
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "correlationId")]
        public string CorrelationId { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "servicePath")]
        public string ServicePath { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "logType")]
        public LogType LogType { get; set; }
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
