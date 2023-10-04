using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Shopping.Entity
{
    public class NoSQLBaseEntity : CommonEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public new string Id { get; set; } = string.Empty;
        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;
    }
}
