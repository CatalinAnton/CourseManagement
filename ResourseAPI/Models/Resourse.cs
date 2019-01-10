using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ResourseAPI.Models
{
    public class Resourse
    {

        public ObjectId _id { get; private set; }

        [BsonElement("Type")]
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }

        [BsonElement("Link")]
        [Required(ErrorMessage = "Link is required")]
        public string Link { get; set; }

        [BsonElement("type")]
        public string Type { get; private set; }

        [BsonElement("link")]
        public string Link { get; private set; }

        [BsonElement("file")]
        public string File { get; private set; }

        public ObjectId CourseId { get; private set; }
    }
}
