using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthAPI.Models
{
    public class Token
    {
        public string Authorization { get; private set; }

        public Token(string Authorization)
        {
            this.Authorization = Authorization;
        }
    }
}