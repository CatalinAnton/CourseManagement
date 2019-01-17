using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AuthAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AuthAPI.Services
{
    public class SessionService
    {
        private readonly IMongoCollection<Session> _sessions;
        private readonly IMongoCollection<User> _users;

        public SessionService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("CourseManagementDB"));
            var database = client.GetDatabase("CourseManagementDB");
            _sessions = database.GetCollection<Session>("Sessions");

            var usersClient = new MongoClient(config.GetConnectionString("CourseManagementDB"));
            var usersDatabase = client.GetDatabase("CourseManagementDB");
            _users = database.GetCollection<User>("Users");
        }

        public Session Get(string token)
        {
            return _sessions.Find<Session>(session => session.Token == token).FirstOrDefault();
        }

        public Session Create(User user)
        {
            var User = _users.Find<User>(userFromDb => userFromDb.Email == user.Email && userFromDb.Password == user.Password).FirstOrDefault();

            if (User != null)
            {
                string Token = new ObjectId().ToString();
                Session session = new Session(user._id.ToString(), Token);
                _sessions.InsertOne(session);
                return session;
            }
            else
            {
                return null;
            }
        }

        public void Remove(ObjectId id)
        {
            _sessions.DeleteOne(session => session._id == id);
        }
    }
}
