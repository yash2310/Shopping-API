using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Shopping.Shared.Enum;

namespace Shopping.Entity
{
    public class LogEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public string CorrelationId { get; set; } = string.Empty;
        public string ServicePath { get; set; } = string.Empty;
        public LogType LogType { get; set; }
        public string Message { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
