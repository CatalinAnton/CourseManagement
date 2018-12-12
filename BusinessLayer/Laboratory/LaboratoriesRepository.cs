using System;
using System.Collections.Generic;
using System.Linq;
using Project.DataLayer;

namespace Project.BusinessLayer
{
    public class LaboratoriesRepository : ILaboratoriesRepository
    {
        private readonly LaboratoriesContext context;

        public LaboratoriesRepository(LaboratoriesContext context)
        {
            this.context = context;
        }
        public void Create(Laboratories laboratory)
        {
            if (laboratory != null)
            {
                this.context.Laboratories.Add(laboratory);
                this.context.SaveChanges();
            }
        }

        public Laboratories GetById(Guid id)
        {
            return this.context.Laboratories.FirstOrDefault(t => t.Id == id);
        }

        public IReadOnlyList<Laboratories> GetAll()
        {
            return this.context.Laboratories.ToList();
        }
    }
}