using librarycompany.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarycompany.Models
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }
        public string StaffName { get; set; }
        public string position { get; set; }
       
        [ForeignKey(nameof(Branch))]
        public int branchid { get; set; }
        public Branche Branch { get; set; }

        public ICollection<Contact> contacts { get; set; } = new List<Contact>();
        public void showContactsOfStaff(ApplicationDbcontext application)
        {
            var con = application.Staffs
                .Include(b => b.contacts)
                .ToList();

            foreach (var c in con)
            {
                foreach (var s in c.contacts)
                {
                    Console.WriteLine($"the Publichername {c.StaffName} The Number of Publicher {s.phonenumber}");
                }
            }
        }

        public static void AddStaff(ApplicationDbcontext application)
        {
            Console.WriteLine("\n--- Add New Staff ---");
            Staff staff = new Staff();

            Console.Write("Enter staff name: ");
            staff.StaffName = Console.ReadLine();

            Console.Write("Enter position: ");
            staff.position = Console.ReadLine();

            Console.Write("Enter Branch ID: ");
            staff.branchid = int.Parse(Console.ReadLine());

            application.Staffs.Add(staff);
            application.SaveChanges();
            Console.WriteLine("Staff added successfully!");
        }
    }
}