using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using gcsharpRPC.Models;

namespace gcsharpRPC.Helpers
{
    public class TrungContext : IdentityDbContext
    {
        // Dependedency Injection
        protected readonly IConfiguration Configuration;

        public TrungContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Poll>()
                .HasMany(x => x.UserVotes)
                .WithOne(x => x.Poll);
            modelBuilder.Entity<UserVote>()
                .HasMany(x => x.Options)
                .WithMany(x => x.UserVotes);
        }

        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollOption> PollOptions { get; set; }
        public DbSet<UserVote> UserVotes { get; set; }
    }
}