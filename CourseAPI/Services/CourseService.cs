using System.Collections.Generic;
using System.Linq;
using CourseAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CourseAPI.Services
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

            return _courses.Find<Course>(course => course.ID == docId).FirstOrDefault();
        }

        public Course Create(Course course)
        {
            _courses.InsertOne(course);
            return course;
        }

        public void Update(string id, Course courseIn)
        {
            var docId = new ObjectId(id);

            _courses.ReplaceOne(course => course.ID == docId, courseIn);
        }

        public void Remove(Course courseIn)
        {
            _courses.DeleteOne(course => course.ID == courseIn.ID);
        }

        public void Remove(ObjectId id)
        {
            _courses.DeleteOne(course => course.ID == id);
        }
    }
}