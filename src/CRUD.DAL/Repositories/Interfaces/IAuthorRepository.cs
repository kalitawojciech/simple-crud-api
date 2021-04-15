using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CRUD.DAL.Entities;

namespace CRUD.DAL.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        public Task<List<Author>> GetAll();

        public Task<Author> GetById(Guid id);

        public void Remove(Author authorToRemove);

        public Task AddNew(Author authorToAdd);
    }
}
