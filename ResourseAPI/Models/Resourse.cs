using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace ResourseAPI.Models
{
    public class Resourse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("Type")]
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }

        [BsonElement("Link")]
        [Required(ErrorMessage = "Link is required")]
        public string Link { get; set; }
    
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CourseId { get; }
    }
}
