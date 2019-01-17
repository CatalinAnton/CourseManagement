using System.Collections.Generic;
using System.Linq;
using ChatAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ChatAPI.Services
{
    public class ChatService
    {
        private readonly IMongoCollection<Chat> _chat;

        public ChatService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("CourseManagementDB"));
            var database = client.GetDatabase("CourseManagementDB");
            _chat = database.GetCollection<Chat>("Chat");
        }

        public List<Chat> Get()
        {
            return _chat.Find(chat => true).ToList();
        }

        public Chat GetByCourseId(string id)
        {
            return _chat.Find<Chat>(chat => chat.CourseId == id).FirstOrDefault();
        }

        public Chat Create(Chat chat)
        {
            _chat.InsertOne(chat);
            return chat;
        }
    }
}