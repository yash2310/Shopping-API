using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Shopping.Entity
{
    public class NoSQLBaseEntity : CommonEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public new string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;
    }
}
