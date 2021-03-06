﻿using System.Collections.Generic;
using System.Linq;
using ResourseAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ResourseAPI.Utility;

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
            return _resourses.Find<Resourse>(resourse => resourse._id == id).FirstOrDefault();
        }

        public List<Resourse> GetByCourseId(string id)
        {
            return _resourses.Find<Resourse>(resourse => resourse.CourseId == id).ToList();
        }

        public Resourse Create(Resourse resourse)
        {
            resourse.Link = GoogleDriveHelper.UploadFile(resourse.Base64String, resourse.Title, resourse.Type);
            _resourses.InsertOne(resourse);
            return resourse;
        }

        public void Update(string id, Resourse resourseIn)
        {
            _resourses.ReplaceOne(resourse => resourse._id == id, resourseIn);
        }

        public void Remove(Resourse resourseIn)
        {
            _resourses.DeleteOne(resourse => resourse._id == resourseIn._id);
        }

        public void Remove(string id)
        {
            _resourses.DeleteOne(resourse => resourse._id == id);
        }
    }
}