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
    public class Publisher
    {
        [Key]
        public int publisherID { get; set; }
        public string Name { get; set; }

        public ICollection<Book> publichbook { get; set; } = new List<Book>();

        public void ShowPublicherBook(ApplicationDbcontext application)
        {
            var publisher = application.Publishers
               .Include(x => x.publichbook)
               .ToList();

            foreach(var n in publisher)
            {
                foreach (var x in n.publichbook)
                {
                    Console.WriteLine($"Name of Publisher : {n.Name} , Books belonging to the publishing :{x.title} " +
                        $", Year of Publishing : {x.publicationyear}");
                }
            }
        }


        public ICollection<Contact> contacts { get; set; } = new List<Contact>();
        public void showContactsOfPublisher(ApplicationDbcontext application)
        {
            var con = application.Publishers
                .Include(b => b.contacts)
                .ToList();

            foreach (var c in con)
            {
                foreach (var s in c.contacts)
                {
                    Console.WriteLine($"the Publichername {c.Name} The Number of Publicher {s.phonenumber}");
                }
            }
        }
        public static void AddPublisher(ApplicationDbcontext application)
        {
            Console.WriteLine("\n--- Add New Publisher ---");
            Publisher publisher = new Publisher();

           

            Console.Write("Enter name: ");
            publisher.Name = Console.ReadLine();

            application.Publishers.Add(publisher);
            application.SaveChanges();
            Console.WriteLine("Publisher added successfully!");
        }

    }
}
