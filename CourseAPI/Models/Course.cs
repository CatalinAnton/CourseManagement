using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseAPI.Models
{
    public class Course
    {
        public ObjectId _id { get; set; }

        [BsonElement("Year")]
        [Required(ErrorMessage = "Year is required")]
        public string Year { get; set; }

        [BsonElement("Semester")]
        [Required(ErrorMessage = "Semester is required")]
        public string Semester { get; set; }

        [BsonElement("Title")]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [BsonElement("Sessions")]
        public List<Session> Sessions { get; set; }
    }
}