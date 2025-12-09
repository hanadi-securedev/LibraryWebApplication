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
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string nationality { get; set; }
        public string notableworks { get; set; }

        public ICollection<Book> Authorbook { get; set; } = new List<Book>();

        public void ShowAuthorWithBook(ApplicationDbcontext application)
        {
            var authors = application.Authors
                .Include(b => b.Authorbook)
                .ToList();

            foreach (var author in authors) { 
            
            foreach (var s in author.Authorbook)
                {
                    Console.WriteLine($"NAME OF AUTHOR : {author.Name} AND THIR BOOK : {s.title}");
                }
            
            
            }
        }
      

        public static void AddAuthor(ApplicationDbcontext application)
        {
            Console.WriteLine("\n--- Add New Author ---");
            Author author = new Author();

            //Console.Write("Enter Author ID: ");
            //author.AuthorId = int.Parse(Console.ReadLine());

            Console.Write("Enter name: ");
            author.Name = Console.ReadLine();

            Console.Write("Enter nationality: ");
            author.nationality = Console.ReadLine();

            Console.Write("Enter notable works: ");
            author.notableworks = Console.ReadLine();

            application.Authors.Add(author);
            application.SaveChanges();
            Console.WriteLine("✓ Author added successfully!");
        }


        

    }
}
