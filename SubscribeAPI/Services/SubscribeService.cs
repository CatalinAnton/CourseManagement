using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using SubscribeAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace SubscribeAPI.Services
{
    public class SubscribeService
    {
        private readonly IMongoCollection<Subscribe> _subscribe;

        public SubscribeService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("CourseManagementDB"));
            var database = client.GetDatabase("CourseManagementDB");
            _subscribe = database.GetCollection<Subscribe>("Subscribe");
        }

        public List<Subscribe> Get()
        {
            return _subscribe.Find(subscribe => true).ToList();
        }

        public Subscribe Get(string id)
        {
            var docId = new ObjectId(id);

            return _subscribe.Find<Subscribe>(subscribe => subscribe._id == docId).FirstOrDefault();
        }

        public Subscribe Create(Subscribe subscribe)
        {
            _subscribe.InsertOne(subscribe);
            return subscribe;
        }

        public void Update(string id, Subscribe subscribeIn)
        {
            var docId = new ObjectId(id);

            _subscribe.ReplaceOne(subscribe => subscribe._id == docId, subscribeIn);
        }

        public void Remove(Subscribe subscribeIn)
        {
            _subscribe.DeleteOne(subscribe => subscribe._id == subscribeIn._id);
        }

        public void Remove(ObjectId id)
        {
            _subscribe.DeleteOne(subscribe => subscribe._id == id);
        }
    }
}
