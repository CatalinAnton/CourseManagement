using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SubscribeAPI.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
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
    }
}
