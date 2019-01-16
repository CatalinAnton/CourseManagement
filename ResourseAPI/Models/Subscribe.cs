using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;


namespace ResourseAPI.Models
{
    public class Subscribe
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ID_Course { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ID_User { get; set; }
    }
}
