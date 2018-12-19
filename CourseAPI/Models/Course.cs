using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CourseAPI.Models
{
    public class Course
    {
        public ObjectId ID { get; set; }

        [BsonElement("Year")]
        public string Year { get; set; }

        [BsonElement("Semester")]
        public string Semester { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }
    }
}