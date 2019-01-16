using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ResourseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourseAPI.Services
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
            return _subscribe.Find<Subscribe>(subscribe => subscribe._id == id).FirstOrDefault();
        }

        public List<Subscribe> GetByCourseId(string id)
        {
            return _subscribe.Find<Subscribe>(subscribe => subscribe.ID_Course == id).ToList();
        }

        public Subscribe Create(Subscribe subscribe)
        {
            _subscribe.InsertOne(subscribe);
         
            return subscribe;
        }

        public void Update(string id, Subscribe subscribeIn)
        {
            _subscribe.ReplaceOne(subscribe => subscribe._id == id, subscribeIn);
        }

        public void Remove(Subscribe subscribeIn)
        {
            _subscribe.DeleteOne(subscribe => subscribe._id == subscribeIn._id);
        }

        public void Remove(string id)
        {
            _subscribe.DeleteOne(subscribe => subscribe._id == id);
        }
    }
}
