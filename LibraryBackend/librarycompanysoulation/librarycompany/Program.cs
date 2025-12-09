using librarycompany.Context;
using librarycompany.Models;
using librarycompany.Models.Enum;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace librarycompany
{
    public class Program
    {
       public static void Main(string[] args)
        {
            ApplicationDbcontext application = new ApplicationDbcontext();

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n=== Library Management System ===");
                
                Console.WriteLine("1 - Add Author");
                Console.WriteLine("2 - Add Branch");
                Console.WriteLine("3 - Add Genre");
                Console.WriteLine("4 - Add Publisher");
                Console.WriteLine("5 - Add Member");
                Console.WriteLine("6 - Add Book");
                Console.WriteLine("7 - Add Staff");
                Console.WriteLine("8 - Add Transaction");
                Console.WriteLine("9 - Add Contact");
                Console.WriteLine("10 - Show the Staff");
                Console.WriteLine("11 - Show The Book in Branch");
                Console.WriteLine("12 - Show The Number of Branch ");
                Console.WriteLine("13 - Show Author With Thier Book");
                Console.WriteLine("14 - Show The Type Of Book");
                Console.WriteLine("15 - Show Member Of Transaction");
                Console.WriteLine("16 - Show Contact Of Member ");
                Console.WriteLine("17 - Show Publicher Book");
                Console.WriteLine("18 - show Contacts Of Publisher");
                Console.WriteLine("19 - show Contacts Of Staf");
                Console.WriteLine("20 - Show Borrwed Books");

                Console.WriteLine("\n - Exit");
                Console.Write("\nChoose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Author.AddAuthor(application);
                        break;
                    case "2":
                        Branche.AddBranch(application);
                        break;
                    case "3":
                        Genre.AddGenre(application);
                        break;
                    case "4":
                        Publisher.AddPublisher(application);
                        break;
                    case "5":
                        Member.AddMember(application);
                        break;
                    case "6":
                        Book.AddBook(application);
                        break;
                    case "7":
                        Staff.AddStaff(application);
                        break;
                    case "8":
                        Transaction.AddTransaction(application);
                        break;
                    case "9":
                        Contact.AddContact(application);
                        break;
                    case "10":
                        Branche b = new Branche();
                        b.showStaff(application);
                        break;
                    case "11":
                        Branche r = new Branche();
                        r.ShowTheBookinBranch(application);
                        break;

                    case "12":
                        Branche a = new Branche();
                        a.showContactsofBranch(application);
                        break;

                    case "13":
                        Author author = new Author();
                        author.ShowAuthorWithBook(application);
                        break;
                    case "14":
                        Genre genre = new Genre();
                        genre.ShowTheTypeOfBook(application);
                        break;
                    case "15":
                        Member member = new Member();
                        member.ShowMemberOfTransaction(application);
                        break;
                    case "16":
                        Member m = new Member();
                        m.showContactsofMember(application);
                        break;
                    case "17":
                        Publisher publisher = new Publisher();
                        publisher.ShowPublicherBook(application);
                        break;
                    case "18":
                        Publisher publisher1 = new Publisher();
                        publisher1.showContactsOfPublisher(application);
                        break;

                    case "19":
                        Staff staff = new Staff();
                        staff.showContactsOfStaff(application);
                        break;
                    case "20":
                        Transaction transaction = new Transaction();
                        transaction.ShowBorrwedBooks(application);
                        break;
              
                    case "Exit":
                        running = false;
                        Console.WriteLine("Thank you for using Library Management System!");
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }





        }
    }
}
