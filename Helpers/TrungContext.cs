namespace gcsharpRPC.Helpers;

using Microsoft.EntityFrameworkCore;

using gcsharpRPC.Models;

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

    public DbSet<Person> Persons { get; set; }
    public DbSet<Poll> Polls { get; set; }
}