using System;

using Microsoft.EntityFrameworkCore;

using CRUD.DAL.Entities;

namespace CRUD.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = "Wiedźmin",
                    PagesCount = 320,
                    AuthorId = Guid.Parse("450271d8-0091-4bf4-beb0-b899e026560e"),
                    CategoryId = Guid.Parse("db67e008-1c68-463e-a7b2-e75ad5a82a7a")
                },
                new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = "Krzyżacy",
                    PagesCount = 280,
                    AuthorId = Guid.Parse("db67e008-1c68-463e-a7b2-e75ad5a82a7f"),
                    CategoryId = Guid.Parse("db67e008-1c68-463e-a7b2-e75ad5a82a7a")
                }
                );
            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    Id = Guid.Parse("450271d8-0091-4bf4-beb0-b899e026560e"),
                    Name = "Andrzej",
                    Age = 67
                },
                new Author()
                {
                    Id = Guid.Parse("db67e008-1c68-463e-a7b2-e75ad5a82a7f"),
                    Name = "Henryk",
                    Age = 44
                }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = Guid.Parse("db67e008-1c68-463e-a7b2-e75ad5a82a7a"),
                    Name = "Fantasy",
                    Description = "Książki o tematyce fantasy",
                    IsActive = true
                }
                );
        }
    }
}
