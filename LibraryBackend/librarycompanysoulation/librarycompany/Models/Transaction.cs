using librarycompany.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarycompany.Models
{
    public class Transaction
    {
        [Key]
        public int TranscationID { get; set; } 
        public string borrowedbook { get; set; }
        public string duedate { get; set; }
        public int fine { get; set; }
        public string penalties { get; set; }

        [ForeignKey(nameof(Member))]
        public int? memberid { get; set; }
        public Member? Member { get; set; }

        public ICollection<Book> BorrowedBooks { get; set; } = new List<Book>();

        public void ShowBorrwedBooks(ApplicationDbcontext application)
        {
            var broo = application.Transactions
                .Include(b => b.BorrowedBooks).Include(c => c.Member)
                .ToList();
            foreach (var book in broo)
            {

                foreach (var b in book.BorrowedBooks)
                {
                    
                        Console.WriteLine($"Name of BorrowedBook :{book.borrowedbook} The Statue Of Book : {b.avastatus} " +
                            $"Name of Member {book.Member?.Name}");
                    
                }


            }
        }



        public static void AddTransaction(ApplicationDbcontext application)
        {
            Console.WriteLine("\n--- Add New Transaction ---");
            Transaction transaction = new Transaction();

            Console.Write("Enter borrowed book (name): ");
             transaction.borrowedbook = Console.ReadLine();

            Console.Write("Enter due date (e.g., 2025-12-31): ");
            transaction.duedate = Console.ReadLine();

            Console.Write("Enter fine amount: ");
            transaction.fine = int.Parse(Console.ReadLine());

            Console.Write("Enter penalties: ");
            transaction.penalties = Console.ReadLine();

            Console.Write("Enter Member ID: ");
            transaction.memberid = int.Parse(Console.ReadLine());

            application.Transactions.Add(transaction);
            application.SaveChanges();
            Console.WriteLine("Transaction added successfully!");
        }
    }
}
