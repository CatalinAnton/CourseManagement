using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AuthAPI.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [BsonElement("Password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [BsonElement("Role")]
        public string Role { get; set; }

        [BsonElement("IsActive")]
        public bool IsActive { get; set; }
    }
}