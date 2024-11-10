using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Bookstore.Model.DatabaseModel
{
    public class BookstoreDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Language> Languages { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //primary keys
            modelBuilder.Entity<Article>().HasKey(a => a.Id);
            modelBuilder.Entity<Bill>().HasKey(b => b.Id);
            modelBuilder.Entity<BillItem>().HasKey(bi => bi.Id);
            modelBuilder.Entity<Language>().HasKey(l => l.Id);
            modelBuilder.Entity<Employee>().HasKey(e => e.Id);
            modelBuilder.Entity<Publisher>().HasKey(p => p.Id);
            modelBuilder.Entity<Author>().HasKey(a => a.Id);

            modelBuilder.Entity<Book>().HasOne(b => b.Publisher).WithMany(p => p.Books).HasForeignKey(b => b.PublisherId);

            modelBuilder.Entity<Book>().HasOne(b => b.Language).WithMany(l => l.Books).HasForeignKey(b => b.LanguageId);

            modelBuilder.Entity<Book>().HasMany(b => b.Authors).WithMany(a => a.Books);

            modelBuilder.Entity<BillItem>().HasOne(bi => bi.Article).WithMany(a => a.BillItems).HasForeignKey(bi => bi.ArticleId);

            modelBuilder.Entity<BillItem>().HasOne(bi => bi.Bill).WithMany(b => b.BillItems).HasForeignKey(bi => bi.BillId);

            modelBuilder.Entity<Bill>().HasOne(b => b.Employee).WithMany(e => e.Bills).HasForeignKey(b => b.EmployeeId);

        }
    }
}
