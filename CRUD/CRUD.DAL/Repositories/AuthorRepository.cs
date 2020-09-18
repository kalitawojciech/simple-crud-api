﻿using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using CRUD.DAL.Entities;
using CRUD.DAL.Repositories.Interfaces;
using System.Linq;
using System;

namespace CRUD.DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAllAuthor()
        {
            List<Author> result = await _context.Author.ToListAsync();

            return result;
        }
    }
}
