using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseAPI.Models
{
    public class Course
    {
        public ObjectId _id { get; private set; }

        [BsonElement("Year")]
        [Required(ErrorMessage = "Year is required")]
        public string Year { get; set; }

        [BsonElement("Semester")]
        [Required(ErrorMessage = "Semester is required")]
        public string Semester { get; set; }

        [BsonElement("Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [BsonElement("Title")]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [BsonElement("Finals")]
        public List<Final> Finals { get; set; }
    }
}