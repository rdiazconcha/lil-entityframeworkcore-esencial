using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Consultas
{
 class Program
    {
        static void Main(string[] args)
        {
            var db = new MusicDbContext();

            var results = db.Bands
                            .Include(b => b.Albums)
                            .ToListAsync().Result;

            foreach (var band in results) {
                System.Console.WriteLine(band.Name);
                foreach (var album in band.Albums){
                    System.Console.WriteLine("    " + album.Title);
                }

                System.Console.WriteLine();
            }

        }

        static void Simple(){
            var db = new MusicDbContext();

            var results = db.Bands.ToListAsync().Result;

            foreach (var band in results){
                System.Console.WriteLine(band.Name);
            }
        }

        static void Insert(){
            var db = new MusicDbContext();
             var newBand = new Band();
            newBand.Name = "Pearl Jam";

            var newAlbum = new Album();
            newAlbum.Title = "Ten";
            newAlbum.Year = 1991;
            newAlbum.Style = MusicStyle.Grunge;

            newBand.Albums = new List<Album>();
            newBand.Albums.Add(newAlbum);

            db.Bands.Add(newBand);


            db.SaveChanges();

            System.Console.WriteLine("Presione cualquier tecla...");
            Console.ReadLine();
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
