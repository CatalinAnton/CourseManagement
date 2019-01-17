using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace ResourseAPI.Models
{
    public class Resourse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("Title")]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [BsonElement("Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }


        [BsonElement("Type")]
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }

        // [BsonElement("Raw")]
        // [Required(ErrorMessage = "File is required")]
        // public Microsoft.AspNetCore.Http.Internal.FormFile Raw { get; set; }

        [BsonElement("Link")]
        [Required(ErrorMessage = "Link is required")]
        public string Link { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CourseId { get; set; }
    }
}
