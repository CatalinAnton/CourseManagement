using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace ResourseAPI.Models
{
    public class Resourse
    {

        public ObjectId _id { get; private set; }

        [BsonElement("title")]
        public string Title { get; private set; }

        [BsonElement("description")]
        public string Description { get; private set; }

        [BsonElement("type")]
        public string Type { get; private set; }

        [BsonElement("link")]
        public string Link { get; private set; }

        [BsonElement("file")]
        public string File { get; private set; }

        public ObjectId CourseId { get; private set; }
    }
}
