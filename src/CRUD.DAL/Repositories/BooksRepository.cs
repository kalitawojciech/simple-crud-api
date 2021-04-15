using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using CRUD.DAL.Entities;
using CRUD.DAL.Repositories.Interfaces;
using System.Linq;
using System;

namespace CRUD.DAL.Repositories
{
    public class BooksRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BooksRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddNew(Book bookToAdd)
        {
            await _context.Books.AddAsync(bookToAdd);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAll()
        {
            List<Book> result = await _context.Books
                .Include(b => b.Author)
                .ToListAsync();

            return result;
        }

        public async Task<Book> GetById(Guid bookId)
        {
            Book bookFromDb = await _context.Books
                .Include(b => b.Author)
                .Where(b => b.Id == bookId)
                .FirstOrDefaultAsync();

            return bookFromDb;
        }

        public async Task<Book> GetByTitle(string bookTitle)
        {
            Book bookFromDb = await _context.Books.Where(b => b.Title.ToLower() == bookTitle.ToLower()).FirstOrDefaultAsync();

            return bookFromDb;
        }

        public void Remove(Book bookToRemove)
        {
            _context.Books.Remove(bookToRemove);
            _context.SaveChanges();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
