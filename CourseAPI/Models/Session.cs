using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthAPI.Models
{
    public class Session
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; private set; }

        [BsonElement("User_ID")]
        public string UserID { get; private set; }

        [BsonElement("Token")]
        public string Token { get; private set; }

        public Session(string UserID, string Token)
        {
            this._id = new ObjectId();
            this.UserID = UserID;
            this.Token = Token;
        }
    }
}