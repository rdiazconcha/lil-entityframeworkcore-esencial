using System;
using Microsoft.EntityFrameworkCore;

namespace Movies
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Escriba el nombre de la película:");
            var name = Console.ReadLine();
            System.Console.WriteLine("Escriba el año de estreno:");
            var year = Console.ReadLine();

            var newMovie = new Movie();
            newMovie.Name = name;
            newMovie.Year = int.Parse(year);

            var db = new MoviesDbContext();
            db.Movies.Add(newMovie);

            var result = db.SaveChanges();

            if (result == 1){
                System.Console.WriteLine("La película ha sido guardada exitosamente");
            }
            else{
                System.Console.WriteLine("Error");
            }

            System.Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadLine();

        }
    }

    class Movie {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }

    class MoviesDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Data source=(localdb)\MSSQLLocalDB; Initial Catalog=Movies;Integrated Security=true");
        }
        public DbSet<Movie> Movies {get; set;}
    }
}
