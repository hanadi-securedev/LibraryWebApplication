using librarycompany.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarycompany.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public int phonenumber { get; set; }

        [ForeignKey(nameof(Publisher))]
        public int publich { get; set; }
        public Publisher Publisher { get; set; }

        [ForeignKey(nameof(Branch))]
        public int branchbookid { get; set; }
        public Branche Branch { get; set; }

        [ForeignKey(nameof(Staff))]
        public int staffid { get; set; }
        public Staff Staff { get; set; }

        [ForeignKey(nameof(Member))]
        public int memberid { get; set; }
        public Member Member { get; set; }

        public static void AddContact(ApplicationDbcontext application)
        {
            Console.WriteLine("\n--- Add New Contact ---");
            Contact contact = new Contact();

           
            Console.Write("Enter phone number: ");
            contact.phonenumber = int.Parse(Console.ReadLine());

            Console.Write("Enter Publisher ID: ");
            contact.publich = int.Parse(Console.ReadLine());

            Console.Write("Enter Branch ID: ");
            contact.branchbookid = int.Parse(Console.ReadLine());

            Console.Write("Enter Staff ID: ");
            contact.staffid = int.Parse(Console.ReadLine());

            Console.Write("Enter Member ID: ");
            contact.memberid = int.Parse(Console.ReadLine());

            application.Contacts.Add(contact);
            application.SaveChanges();
            Console.WriteLine("Contact added successfully!");
        }
    }
}
