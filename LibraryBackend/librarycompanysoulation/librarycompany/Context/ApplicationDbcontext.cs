using librarycompany.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarycompany.Context
{
    public  class ApplicationDbcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
             *Data Source=LAPTOPGHDRBIV4\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False
             */
            string con = "Data Source=LAPTOPGHDRBIV4\\SQLEXPRESS;Database=librarycompany;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";
            optionsBuilder.UseSqlServer(con);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Branche> Branches { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
           .Property(b => b.ISBN)
           .ValueGeneratedOnAdd();

       modelBuilder.Entity<Book>()
       .HasOne(b => b.Transaction)
       .WithMany(t => t.BorrowedBooks)
       .HasForeignKey(b => b.TransactionId)
       .IsRequired(false)  
       .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Publisher)
                .WithMany(p => p.contacts)
                .HasForeignKey(c => c.publich)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Branch)
                .WithMany(b => b.contacts)
                .HasForeignKey(c => c.branchbookid)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Staff)
                .WithMany(s => s.contacts)
                .HasForeignKey(c => c.staffid)
                .OnDelete(DeleteBehavior.Restrict); 


            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Member)
                .WithMany(m => m.contacts)
                .HasForeignKey(c => c.memberid)
                .OnDelete(DeleteBehavior.Restrict); 


            modelBuilder.Entity<Staff>()
                .HasOne(s => s.Branch)
                .WithMany(b => b.branchstaff)
                .HasForeignKey(s => s.branchid)
                .OnDelete(DeleteBehavior.Restrict);
        }
        
        }
}
