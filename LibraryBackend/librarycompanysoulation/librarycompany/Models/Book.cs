using librarycompany.Context;
using librarycompany.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarycompany.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ISBN { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int publicationyear { get; set; }
        public Availabilitystatus avastatus { get; set; }

        [ForeignKey(nameof(Transaction))]
        public int? TransactionId { get; set; }
        public Transaction? Transaction { get; set; }

        [ForeignKey(nameof(Branch))]
        public int branchid { get; set; }
        public Branche Branch { get; set; }

        [ForeignKey(nameof(Genre))]
        public int genr { get; set; }
        public Genre Genre { get; set; }

        [ForeignKey(nameof(Publisher))]
        public int publich { get; set; }
        public Publisher Publisher { get; set; }

        [ForeignKey(nameof(Author))]
        public int AuthorID { get; set; }
        public Author Author { get; set; }


        public static void AddBook(ApplicationDbcontext application)
        {
            Console.WriteLine("\n--- Add New Book ---");
            Book book = new Book();


            Console.Write("Enter title: ");
            book.title = Console.ReadLine();

            Console.Write("Enter author name: ");
            book.author = Console.ReadLine();

            Console.Write("Enter publication year: ");
            book.publicationyear = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose Availability Status:");
            Console.WriteLine("1 - Available");
            Console.WriteLine("2 - Borrowed");
            Console.Write("Enter number: ");
            int statusNum = int.Parse(Console.ReadLine());
            book.avastatus = (Availabilitystatus)(statusNum - 1);

            Console.WriteLine("\n--- Available Branches ---");
            foreach (var b in application.Branches)
            {
                Console.WriteLine($"{b.ID} - {b.Name} ({b.city})");
            }
            Console.Write("Enter Branch ID: ");
            book.branchid = int.Parse(Console.ReadLine());

            Console.WriteLine("\n--- Available Genres ---");
            foreach (var g in application.Genres)
            {
                Console.WriteLine($"{g.GenreId} - {g.GenreTypename}");
            }
            Console.Write("Enter Genre ID: ");
            book.genr = int.Parse(Console.ReadLine());

            Console.WriteLine("\n--- Available Publishers ---");
            foreach (var p in application.Publishers)
            {
                Console.WriteLine($"{p.publisherID} - {p.Name}");
            }
            Console.Write("Enter Publisher ID: ");
            book.publich = int.Parse(Console.ReadLine());

            Console.WriteLine("\n--- Available Authors ---");
            foreach (var a in application.Authors)
            {
                Console.WriteLine($"{a.AuthorId} - {a.Name}");
            }
            Console.Write("Enter Author ID: ");
            book.AuthorID = int.Parse(Console.ReadLine());

            

            Console.Write("\n Enter The TransactionId of Book if it availibel press Enter to skip): ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                book.TransactionId = int.Parse(input);
            }
            else
            {
                book.TransactionId = null;  
            }




            application.Books.Add(book);
            application.SaveChanges();

            Console.WriteLine($"✓ Book added successfully! ISBN: {book.ISBN}");
        }
   
    }
}
