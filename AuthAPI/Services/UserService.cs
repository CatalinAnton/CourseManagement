using System.Collections.Generic;
using System.Linq;
using AuthAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AuthAPI.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("CourseManagementDB"));
            var database = client.GetDatabase("CourseManagementDB");
            _users = database.GetCollection<User>("User");
        }

        public List<User> Get()
        {
            return _users.Find(user => true).ToList();
        }

        public User Get(string id)
        {
            var docId = new ObjectId(id);

            return _users.Find<User>(user => user.ID == docId).FirstOrDefault();
        }

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn)
        {
            var docId = new ObjectId(id);

            _users.ReplaceOne(user => user.ID == docId, userIn);
        }

        public void Remove(User userIn)
        {
            _users.DeleteOne(user => user.ID == userIn.ID);
        }

        public void Remove(ObjectId id)
        {
            _users.DeleteOne(user => user.ID == id);
        }
    }
}
