using Microsoft.EntityFrameworkCore;
using gcsharpRPC.Models;

namespace gcsharpRPC.Helpers
{
    public class TrungContext : DbContext
    {
        // Dependedency Injection
        protected readonly IConfiguration Configuration;

        public TrungContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Person>().ToTable("Course");
        //     modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
        //     modelBuilder.Entity<Student>().ToTable("Student");
        // }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Poll> Polls { get; set; }
    }
}