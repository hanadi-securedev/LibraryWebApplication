using librarycompany.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarycompany.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        
        public string GenreTypename { get; set; }

        public ICollection<Book> Generhbook { get; set; } = new List<Book>();

        public void ShowTheTypeOfBook(ApplicationDbcontext application)
        {
            var gere = application.Genres
                .Include(g => g.Generhbook)
                .ToList();

            foreach (var g in gere)
            {

                foreach (var b in g.Generhbook)
                {

                    Console.WriteLine($"Type of Books :{g.GenreTypename} , Name of Book : {b.title}");

                }
            }

        }

        public static void AddGenre(ApplicationDbcontext application)
        {
            Console.WriteLine("\n--- Add New Genre ---");
            Genre genre = new Genre();

            Console.Write("Enter genre type name: ");
            genre.GenreTypename = Console.ReadLine();

            application.Genres.Add(genre);
            application.SaveChanges();
            Console.WriteLine("Genre added successfully!");
        }

    }
}
