using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD.DAL.Entities;
using CRUD.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddNew(Author authorToAdd)
        {
            await _context.Author.AddAsync(authorToAdd);
            await _context.SaveChangesAsync();
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<List<Author>> GetAll()
        {
            List<Author> result = await _context.Author
                .Include(a => a.Books)
                .ToListAsync();

            return result;
        }

        public async Task<Author> GetById(Guid id)
        {
            Author result = await _context.Author
                .Include(a => a.Books)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            return result;
        }

        public void Remove(Author authorToRemove)
        {
            _context.Author.Remove(authorToRemove);
            _context.SaveChanges();
        }
    }
}
