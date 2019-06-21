using System;
using Microsoft.EntityFrameworkCore;

namespace Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Album {
        public int Id { get; set; }

        public string Title { get; set; }

        public MusicStyle Style { get; set; }
    }

    enum MusicStyle{
        Grunge,
        Soul,
        Blues,
        Hiphop,
        Metal
    }

    class MusicDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Data source=(localdb)\MSSQLLocalDB; Initial Catalog=Movies;Integrated Security=true");
        }
        public DbSet<Album> Albums {get; set;}
    }
}
