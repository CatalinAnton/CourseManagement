using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CourseAPI.Models
{
    public class Course
    {
        public ObjectId _id { get; private set; }

        [BsonElement("title")]
        public string Title { get; private set; }

        [BsonElement("description")]
        public string Description { get; private set; }

        [BsonElement("date")]
        public string Date { get; private set; }
    }
}