using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AuthAPI.Models;
using AuthAPI.Utility;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AuthAPI.Services
{
    public class SessionsService
    {
        private readonly IMongoCollection<Session> _sessions;
        private readonly IMongoCollection<User> _users;

        public SessionsService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("CourseManagementDB"));
            var database = client.GetDatabase("CourseManagementDB");
            _sessions = database.GetCollection<Session>("Sessions");
            _users = database.GetCollection<User>("Users");
        }

        public Session GetSession(string token)
        {
            return _sessions.Find<Session>(session => session.Token == token).FirstOrDefault();
        }

        
        public User GetUser(string token)
        {
            var session = _sessions.Find<Session>(entry => entry.Token == token).FirstOrDefault();

            if (session != null)
            {
                var docId = new ObjectId(session.UserID);
                var user = _users.Find<User>(entry => entry._id == docId).FirstOrDefault();

                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public Token Create(User user)
        {
            var userFromDatabase = _users.Find<User>(entry => entry.Email == user.Email && entry.Password == user.Password).FirstOrDefault();

            if (userFromDatabase != null && userFromDatabase.IsActive)
            {
                string token = TokenProvider.CreateToken(24);
                Session session = new Session(userFromDatabase._id.ToString(), token);
                Token response = new Token(token);
                _sessions.InsertOne(session);
                return response;
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
