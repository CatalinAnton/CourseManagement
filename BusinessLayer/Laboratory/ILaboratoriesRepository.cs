using System;
using System.Collections.Generic;
using Project.DataLayer;

namespace Project.BusinessLayer
{
    public interface ILaboratoriesRepository
    {
        void Create(Laboratories laboratory);
        IReadOnlyList<Laboratories> GetAll();
        Laboratories GetById(Guid id);
    }
}