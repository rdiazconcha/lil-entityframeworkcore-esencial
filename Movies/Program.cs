using System;
using Microsoft.EntityFrameworkCore;

namespace Movies
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class Movie {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }

    public class MoviesDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Data source=(localdb)\MSSQLLocalDB; Initial Catalog=Movies;Integrated Security=true");
        }
        protected MoviesDbContext()
        {
        }

        public DbSet<Movie> Movies {get; set;}
    }
}
