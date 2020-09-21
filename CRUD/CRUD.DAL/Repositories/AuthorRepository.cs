using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using CRUD.DAL.Entities;
using CRUD.DAL.Repositories.Interfaces;

namespace CRUD.DAL.Repositories
{
    public class AuthorRepository : IAuthorsRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddNewAuthor(Author authorToAdd)
        {
            await _context.Author.AddAsync(authorToAdd);
            await _context.SaveChangesAsync();
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<List<Author>> GetAllAuthor()
        {
            List<Author> result = await _context.Author
                .Include(a => a.Books)
                .ToListAsync();

            return result;
        }

        public async Task<Author> GetAuthorById(Guid id)
        {
            Author result = await _context.Author
                .Include(a => a.Books)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            return result;
        }

        public void RemoveAuthor(Author authorToRemove)
        {
            _context.Author.Remove(authorToRemove);
            _context.SaveChanges();
        }
    }
}
