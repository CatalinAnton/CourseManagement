using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ResourseAPI.Models
{
    public class Resourse
    {

        public ObjectId _id { get; set; }

        [BsonElement("Type")]
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }

        [BsonElement("Link")]
        [Required(ErrorMessage = "Link is required")]
        public string Link { get; set; }

        public ObjectId CourseId { get; }
    }
}
