using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using CRUD.DAL.Entities;
using CRUD.DAL.Repositories.Interfaces;

namespace CRUD.DAL.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly AppDbContext _context;
        public BooksRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            List<Book> result = await _context.Books.ToListAsync();

            return result;
        }
    }
}
