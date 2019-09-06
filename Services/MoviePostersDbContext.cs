using Microsoft.EntityFrameworkCore;
using MoviePostersAPI.Entities;

namespace MoviePostersAPI.Services
{
    public class MoviePostersDbContext : DbContext
    {

        public DbSet<MoviePoster> MoviePosters { get; set; }

        public MoviePostersDbContext (DbContextOptions<MoviePostersDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .Property(r => r.PostedDate)
                .HasDefaultValueSql("getDate()");
        }
        
    }
}