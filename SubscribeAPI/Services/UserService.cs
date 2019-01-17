using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SubscribeAPI.Models;
using System.Collections.Generic;
using System.Linq;


namespace SubscribeAPI.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _user;

        public UserService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("CourseManagementDB"));
            var database = client.GetDatabase("CourseManagementDB");
            _user = database.GetCollection<User>("User");
        }

        public List<User> Get()
        {
            return _user.Find(user => true).ToList();
        }

        public User Get(string id)
        {
            return _user.Find<User>(user => user._id == id).FirstOrDefault();
        }

        public User Create(User user)
        {
            _user.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn)
        {
            _user.ReplaceOne(user => user._id == id, userIn);
        }

        public void Remove(User userIn)
        {
            _user.DeleteOne(user => user._id == userIn._id);
        }

        public void Remove(string id)
        {
            _user.DeleteOne(user => user._id == id);
        }
    }
}
