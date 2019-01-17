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

        public SessionService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("CourseManagementDB"));
            var database = client.GetDatabase("CourseManagementDB");
            _sessions = database.GetCollection<Session>("Sessions");
        }

        public Session Get(string token)
        {
            return _sessions.Find<Session>(session => session.Token == token).FirstOrDefault();
        }
    }
}
