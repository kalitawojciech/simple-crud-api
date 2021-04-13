using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CRUD.DAL.Entities;
using CRUD.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll()
        {
            List<Category> categories = 
                await _context
                    .Categories
                    .Include(c => c.Books)
                    .ThenInclude(b => b.Author)
                    .ToListAsync();

            return categories;
        }

        public async Task<Category> GetById(Guid id)
        {
            Category category =
                await _context
                    .Categories
                    .Include(c => c.Books)
                    .ThenInclude(b => b.Author)
                    .Where(c => c.Id == id)
                    .FirstOrDefaultAsync();

            return category;
        }
    }
}
