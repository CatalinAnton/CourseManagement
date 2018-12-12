using Microsoft.EntityFrameworkCore;

namespace Project.DataLayer
{
    public sealed class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Courses> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

}