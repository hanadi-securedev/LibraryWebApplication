using librarycompany.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization.Formatters;
namespace librarycompany.Models
{
    public class Branche
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string city { get; set; }

        public string street { get; set; }


        public ICollection<Staff> branchstaff = new List<Staff>();
        public ICollection<Book> branchbooks { get; set; } = new List<Book>();
        public void showStaff(ApplicationDbcontext application)
        {

            var branches = application.Branches
            .Include(b => b.branchstaff)  
            .ToList();

            foreach (var b in branches)
            {
        
                foreach (var s in b.branchstaff)
                {
                    Console.WriteLine($"  The ID OF STAFF : {s.StaffID}, The NAME OF STAFF : {s.StaffName}, The POSITION OF STAFF : {s.position}" +
                        $"THE BRANCHNAME OF STAFF WORK : {b.Name} ");
                }
            }
        
    


        }

        public void ShowTheBookinBranch (ApplicationDbcontext application)
        {
            var book = application.Branches
                .Include(b => b.branchbooks)
                .ToList();

            foreach (var b in book)
            {
                foreach(var s in b.branchbooks)
                {
                    Console.WriteLine($"TITLE OF BOOK : {s.title}, AUTHOR NAME OF BOOK : {s.author} STATUE OF BOOK : {s.avastatus}, PUBLICATIONYEAROfBOOK : {s.publicationyear}" +
                        $" ISBN OF BOOK :{s.ISBN} THE BOOK IN BRANCH  ");
                }
            }
        }

        public ICollection<Contact> contacts = new List<Contact>();

        public void showContactsofBranch (ApplicationDbcontext application)
        {
            var con = application.Branches
                .Include (b => b.contacts)
                .ToList();

           foreach(var c in con)
            {
                foreach( var s in c.contacts)
                {
                    Console.WriteLine($"the branchname {c.Name} The Number of Branch {s.phonenumber}" );
                }
            }
        }
        

        public static void AddBranch(ApplicationDbcontext application)
        {
            Console.WriteLine("\n--- Add New Branch ---");
            Branche branch = new Branche();

            //Console.Write("Enter Branch ID: ");
            //branch.ID = int.Parse(Console.ReadLine());

            Console.Write("Enter name: ");
            branch.Name = Console.ReadLine();

            Console.Write("Enter city: ");
            branch.city = Console.ReadLine();

            Console.Write("Enter street: ");
            branch.street = Console.ReadLine();

            application.Branches.Add(branch);
            application.SaveChanges();
            Console.WriteLine("Branch added successfully!");
        }
    }
}
