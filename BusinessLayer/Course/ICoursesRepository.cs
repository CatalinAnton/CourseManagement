using System;
using System.Collections.Generic;
using Project.DataLayer;

namespace Project.BusinessLayer
{
    public interface ICourseRepository
    {
        void Create(Courses course);
        IReadOnlyList<Courses> GetAll();
        Courses GetById(Guid id);
    }
}