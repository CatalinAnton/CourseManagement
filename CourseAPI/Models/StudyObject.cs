using AuthAPI.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace CourseAPI.Models
{
    public class StudyObject
    {
        public ObjectId _id { get; set; }

        [BsonElement("Year")]
        public string Year { get; set; }

        [BsonElement("Semester")]
        public string Semester { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Teacher")]
        public User Teacher { get; set; }
    }
}
