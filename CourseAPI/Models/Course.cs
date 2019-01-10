using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace CourseAPI.Models
{
    public class Course
    {
        public ObjectId _id { get; set; }

        [BsonElement("Year")]
        public string Year { get; set; }

        [BsonElement("Semester")]
        public string Semester { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Sessions")]
        public List<Session> Sessions { get; set; }
    }
}