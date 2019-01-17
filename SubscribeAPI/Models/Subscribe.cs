using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SubscribeAPI.Models
{
    public class Subscribe
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; private set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ID_Course { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ID_User { get; set; }

    }
}
