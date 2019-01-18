using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ResourseAPI.Models;

// this is a session from a course or from a lab.
// for example: Course Mathematics, with session 1 on week1, session 2 on week 2, and so on
namespace CourseAPI.Models
{
    public class Final
    {
        public ObjectId _id { get; set; }

        [BsonElement("Attendace")]
        public List<ObjectId> Attendace { get; set; }

        [BsonElement("Date")]
        public DateTime Date { get; set; }

        [BsonElement("Resources")]
        public List<Resourse> Resources { get; set; }
    }
}
