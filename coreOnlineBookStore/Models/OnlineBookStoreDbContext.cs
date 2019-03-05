using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreOnlineBookStore.Models
{
    public class OnlineBookStoreDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> Categorys { get; set; }
       public DbSet<Author> Authors { get; set; }
        public DbSet<Publication> Publications { get; set; }

      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=TRD-512;Initial Catalog=OnlineBookStoreDb;Integrated Security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(a => a.Author)
                .WithMany(b => b.Books)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Book>()
                 .HasOne(a => a.BookCategory)
                 .WithMany(b => b.Books)
                 .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Book>()
                 .HasOne(a => a.Publication)
                 .WithMany(b => b.Books)
                 .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
    

