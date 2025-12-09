using librarycompany.Context;
using librarycompany.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarycompany.Models
{
    public class Member
    {
        [Key]
        public int MembershipId { get; set; }
        public string Name { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public Membertype mtype { get; set; }

        public ICollection<Transaction> transactionbook { get; set; } = new List<Transaction>();
        public void ShowMemberOfTransaction (ApplicationDbcontext application)
        {
            var member = application.Members
                .Include(x => x.transactionbook)
                .ToList();

            foreach(var s in member)
            {
                foreach (var m in s.transactionbook)
                {
                    Console.WriteLine($"The Member is : {s.mtype} Name Of Member {s.Name} " +
                        $"The Book His Token : {m.borrowedbook} The DueDate : {m.duedate} The fine {m.fine} The penalties {m.penalties}");
                }
            }

        }
        public ICollection<Contact> contacts { get; set; } = new List<Contact>();

        public void showContactsofMember(ApplicationDbcontext application)
        {
            var con = application.Members
                .Include(b => b.contacts)
                .ToList();

            foreach (var c in con)
            {
                foreach (var s in c.contacts)
                {
                    Console.WriteLine($"the Membername {c.Name} The Number of Member {s.phonenumber}");
                }
            }
        }


        public static void AddMember(ApplicationDbcontext application)
        {
            Console.WriteLine("\n--- Add New Member ---");
            Member member = new Member();

            Console.Write("Enter name: ");
            member.Name = Console.ReadLine();

            Console.Write("Enter city: ");
            member.city = Console.ReadLine();

            Console.Write("Enter street: ");
            member.street = Console.ReadLine();

            Console.WriteLine("Choose Member Type:");
            Console.WriteLine("1 - Student");
            Console.WriteLine("2 - Researcher");
            Console.WriteLine("3 - Reader");
            Console.Write("Enter number: ");
            int typeNum = int.Parse(Console.ReadLine());
            member.mtype = (Membertype)(typeNum - 1);

            application.Members.Add(member);
            application.SaveChanges();
            Console.WriteLine("Member added successfully!");
        }


    }
}
