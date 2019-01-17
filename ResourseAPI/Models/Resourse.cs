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

        [BsonElement("Base64String")]
        [Required(ErrorMessage = "Base64 file encoding is required")]
        public string Base64String { get; set; }

        [BsonElement("Link")]
        [Required(ErrorMessage = "Link is required")]
        public string Link { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CourseId { get; set; }


        static public string EncodeTo64(string toEncode)
        {
      byte[] toEncodeAsBytes 
            = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
      string returnValue 
            = System.Convert.ToBase64String(toEncodeAsBytes);
      return returnValue;
        }

        static public string DecodeFrom64(string encodedData)
        {
        byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
        string returnValue = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
         return returnValue;
        }
    }
}
