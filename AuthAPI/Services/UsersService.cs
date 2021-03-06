using System.Collections.Generic;
using System.Linq;
using AuthAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AuthAPI.Services
{
    public class UsersService
    {
        private readonly IMongoCollection<User> _users;

        public UsersService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("CourseManagementDB"));
            var database = client.GetDatabase("CourseManagementDB");
            _users = database.GetCollection<User>("Users");
        }

        public List<User> Get()
        {
            return _users.Find(user => true).ToList();
        }

        public User Get(string id)
        {
            var docId = new ObjectId(id);

            return _users.Find<User>(user => user._id == docId).FirstOrDefault();
        }

        public User Create(User user)
        {
            user.IsActive = user.Role != "teacher";
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn)
        {
            var docId = new ObjectId(id);

            _users.ReplaceOne(user => user._id == docId, userIn);
        }

        public void Remove(User userIn)
        {
            _users.DeleteOne(user => user._id == userIn._id);
        }

        public void Remove(ObjectId id)
        {
            _users.DeleteOne(user => user._id == id);
        }
    }
}
