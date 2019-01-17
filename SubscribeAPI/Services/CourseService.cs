using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using SubscribeAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace SubscribeAPI.Services
{
    public class CourseService
    {
        private readonly IMongoCollection<Course> _courses;

        public CourseService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("CourseManagementDB"));
            var database = client.GetDatabase("CourseManagementDB");
            _courses = database.GetCollection<Course>("Course");
        }

        public List<Course> Get()
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
