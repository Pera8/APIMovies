using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovie>()
                .HasKey(bc => new { bc.MovieId, bc.ActorsId });
            modelBuilder.Entity<ActorMovie>()
                .HasOne(bc => bc.Actor)
                .WithMany(b => b.ActorMovies)
                .HasForeignKey(bc => bc.ActorsId);
            modelBuilder.Entity<ActorMovie>()
                .HasOne(bc => bc.Movie)
                .WithMany(c => c.ActorMovies)
                .HasForeignKey(bc => bc.MovieId);


            modelBuilder.Entity<GenreMovie>()
                .HasKey(bc => new { bc.MovieId, bc.GenreId });
            modelBuilder.Entity<GenreMovie>()
                .HasOne(bc => bc.Genre)
                .WithMany(b => b.GenreMovies)
                .HasForeignKey(bc => bc.GenreId);
            modelBuilder.Entity<GenreMovie>()
                .HasOne(bc => bc.Movie)
                .WithMany(c => c.GenreMovies)
                .HasForeignKey(bc => bc.MovieId);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<GenreMovie> GenreMovies { get; set; }
    }
}
