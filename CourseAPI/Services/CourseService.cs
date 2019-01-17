using System.Collections.Generic;
using System.Linq;
using CourseAPI.Models;
using AuthAPI.Services;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CourseAPI.Services
{
    public class CourseService
    {
        private readonly IMongoCollection<Course> _courses;
        private readonly SessionService _sessionsService;

        public CourseService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("CourseManagementDB"));
            var database = client.GetDatabase("CourseManagementDB");
            _courses = database.GetCollection<Course>("Course");
            _sessionsService = new SessionService(config);
        }

        private SessionService GetSessionService()
        {
            return this._sessionsService;
        }

        public List<Course> Get(string token)
        {
            return _courses.Find(course => true).ToList();
        }

        public Course Get(string id)
        {
            var docId = new ObjectId(id);

            return _courses.Find<Course>(course => course._id == docId).FirstOrDefault();
        }

        public Course Create(Course course)
        {
            _courses.InsertOne(course);
            return course;
        }

        public void Update(string id, Course courseIn)
        {
            var docId = new ObjectId(id);

            _courses.ReplaceOne(course => course._id == docId, courseIn);
        }

        public void Remove(Course courseIn)
        {
            _courses.DeleteOne(course => course._id == courseIn._id);
        }

        public void Remove(ObjectId id)
        {
            _courses.DeleteOne(course => course._id == id);
        }
    }
}