using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthAPI.Models
{
    public class User
    {
        public ObjectId ID { get; set; }

        [BsonElement("Last_Name")]
        public string LastName { get; set; }

        [BsonElement("First_Name")]
        public string FirstName { get; set; }

        [BsonElement("Email")]
        public decimal Email { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("Role")]
        public string Role { get; set; }

        [BsonElement("Is_Active")]
        public string IsActive { get; set; }
    }
}