namespace gcsharpRPC.Helpers;

using Microsoft.EntityFrameworkCore;

using gcsharpRPC.Models;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<Person> Persons { get; set; }
}