using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CRUD.DAL.Entities;

namespace CRUD.DAL.Repositories.Interfaces
{
    public interface IBooksRepository
    {
        public Task<List<Book>> GetAllBooks();

        public Task<Book> GetBookById(Guid bookId);

        public Task AddNewBook(Book bookToAdd);

        public Task<Book> GetBookByTitle(string bookTitle);

        public void RemoveBook(Book bookToRemove);

        public Task SaveChanges();
    }
}
