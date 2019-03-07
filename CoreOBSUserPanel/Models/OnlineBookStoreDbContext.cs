using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreOBSUserPanel.Models
{
    public partial class OnlineBookStoreDbContext : DbContext
    {
        public OnlineBookStoreDbContext()
        {
        }

        public OnlineBookStoreDbContext(DbContextOptions<OnlineBookStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Categorys> Categorys { get; set; }
        public virtual DbSet<Publications> Publications { get; set; }
        public Books BookDetails { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=TRD-512;Database=OnlineBookStoreDb; Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>(entity =>
            {
                entity.HasKey(e => e.AuthorId);

                entity.Property(e => e.AuthorBiography).IsRequired();

                entity.Property(e => e.AuthorImage).IsRequired();

                entity.Property(e => e.AuthorName).IsRequired();
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.HasIndex(e => e.AuthorId);

                entity.HasIndex(e => e.BookCategoryCategoryId);

                entity.HasIndex(e => e.PublicationId);

                entity.Property(e => e.BookImage).IsRequired();

                entity.Property(e => e.BookName).IsRequired();

                entity.Property(e => e.BookType).IsRequired();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.BookCategoryCategory)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.BookCategoryCategoryId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Publication)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublicationId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Categorys>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryDescription).IsRequired();

                entity.Property(e => e.CategoryName).IsRequired();
            });

            modelBuilder.Entity<Publications>(entity =>
            {
                entity.HasKey(e => e.PublicationId);

                entity.Property(e => e.PublicationDescription).IsRequired();

                entity.Property(e => e.PublicationName).IsRequired();
            });
        }
    }
}
