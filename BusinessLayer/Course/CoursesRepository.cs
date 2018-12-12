using System;
using System.Collections.Generic;
using System.Linq;
using Project.DataLayer;

namespace Project.BusinessLayer
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseContext context;

        public CourseRepository(CourseContext context)
        {
            this.context = context;
        }
        public void Create(Courses course)
        {
            if (course != null)
            {
                this.context.Courses.Add(course);
                this.context.SaveChanges();
            }
        }

        public Courses GetById(Guid id)
        {
            return this.context.Courses.FirstOrDefault(t => t.Id == id);
        }

        public IReadOnlyList<Courses> GetAll()
        {
            return this.context.Courses.ToList();
        }
    }
}