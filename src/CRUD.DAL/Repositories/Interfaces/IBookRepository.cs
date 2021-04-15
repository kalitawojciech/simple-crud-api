using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CRUD.DAL.Entities;

namespace CRUD.DAL.Repositories.Interfaces
{
    public interface IBookRepository
    {
        public Task<List<Book>> GetAll();

        public Task<Book> GetById(Guid bookId);

        public Task AddNew(Book bookToAdd);

        public Task<Book> GetByTitle(string bookTitle);

        public void Remove(Book bookToRemove);

        public Task SaveChanges();
    }
}
