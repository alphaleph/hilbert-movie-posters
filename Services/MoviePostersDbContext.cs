using Microsoft.EntityFrameworkCore;
using MoviePostersAPI.Entities;
using System.Linq;

namespace MoviePostersAPI.Services
{
    public class MoviePostersDbContext : DbContext
    {

        public DbSet<MoviePoster> MoviePosters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public MoviePostersDbContext (DbContextOptions<MoviePostersDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .Property(r => r.PostedDate)
                .HasDefaultValueSql("CONVERT(date, GETDATE())");

            modelBuilder.Entity<MoviePoster>()
                .HasOne(mp => mp.Movie)
                .WithMany(m => m.MoviePosters)
                .HasForeignKey(mp => mp.MovieId);
            
            modelBuilder.Entity<Review>()
                .HasOne(r => r.MoviePoster)
                .WithMany(mp => mp.Reviews)
                .HasForeignKey(r => r.MoviePosterId);
        }
    }
}