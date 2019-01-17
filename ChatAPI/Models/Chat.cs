using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ChatAPI.Models
{
    public class Chat
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("DateSent")]
        [Required(ErrorMessage = "")]
        public string DateSent { get; set; }

        [BsonElement("Message")]
        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CourseId { get; set; }
    }
}
