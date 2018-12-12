using Microsoft.EntityFrameworkCore;

namespace Project.DataLayer
{
    public sealed class LaboratoriesContext : DbContext
    {
        public LaboratoriesContext(DbContextOptions<LaboratoriesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Laboratories> Laboratories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }

}