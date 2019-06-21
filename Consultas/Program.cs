using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Consultas
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

        public int Year { get; set; }

        public MusicStyle Style { get; set; }

        public int BandId { get; set; }
    }

    class Band {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Album> Albums { get; set; }

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
            optionsBuilder.UseSqlServer(@"Data source=(localdb)\MSSQLLocalDB; Initial Catalog=Music;Integrated Security=true");
        }
        public DbSet<Album> Albums {get; set;}

        public DbSet<Band> Bands {get;set;}
    }
}
