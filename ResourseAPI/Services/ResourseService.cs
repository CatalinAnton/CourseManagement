using System.Collections.Generic;
using System.Linq;
using ResourseAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ResourseAPI.Services
{
    public class ResourseService
    {
        private readonly IMongoCollection<Resourse> _resourses;

        public ResourseService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("CourseManagementDB"));
            var database = client.GetDatabase("CourseManagementDB");
            _resourses = database.GetCollection<Resourse>("Resourse");
        }

        public List<Resourse> Get()
        {
            return _resourses.Find(resourse => true).ToList();
        }

        public Resourse Get(string id)
        {
            var docId = new ObjectId(id);

            return _resourses.Find<Resourse>(resourse => resourse._id == docId).FirstOrDefault();
        }

        public Resourse Create(Resourse resourse)
        {
            _resourses.InsertOne(resourse);
            return resourse;
        }

        public void Update(string id, Resourse resourseIn)
        {
            var docId = new ObjectId(id);

            _resourses.ReplaceOne(resourse => resourse._id == docId, resourseIn);
        }

        public void Remove(Resourse resourseIn)
        {
            _resourses.DeleteOne(resourse => resourse._id == resourseIn._id);
        }

        public void Remove(ObjectId id)
        {
            _resourses.DeleteOne(resourse => resourse._id == id);
        }
    }
}