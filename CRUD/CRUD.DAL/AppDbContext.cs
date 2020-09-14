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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = "Wiedźmin",
                    PagesCount = 320
                },
                new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = "Krzyżacy",
                    PagesCount = 280
                }
                );
        }
    }
}
