using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourseAPI.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("Last_Name")]
        [Required(ErrorMessage = "Last_Name is required")]
        public string Last_Name { get; set; }

        [BsonElement("First_Name")]
        [Required(ErrorMessage = "First_Name is required")]
        public string First_Name { get; set; }


        [BsonElement("Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [BsonElement("Password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [BsonElement("Role")]
        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        [BsonElement("Is_Active")]
        [Required(ErrorMessage = "Is_Active is required")]
        public bool Is_Active { get; set; }

    }
}
