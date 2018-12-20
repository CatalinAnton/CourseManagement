using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace ResourseAPI.Models
{
    public class Resourse
    {

        public ObjectId _id { get; set; }

        [BsonElement("Type")]
        public string Type { get; set; }

        [BsonElement("Link")]
        public string Link { get; set; }

        public ObjectId CourseId { get; }
    }
}
