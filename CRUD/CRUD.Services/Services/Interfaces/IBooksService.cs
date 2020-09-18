using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CRUD.Services.Dtos.Books.Request;
using CRUD.Services.Dtos.Books.Response;

namespace CRUD.Services.Services
{
    public interface IBooksService
    {
        public Task<List<BookInfoResponse>> GetAllBooks();

        public Task<BookInfoResponse> GetBookById(Guid bookId);

        public Task AddNewBook(AddBookRequest addBookRequest);

        public Task RemoveBook(Guid bookId);

        public Task EditBook(EditBookRequest editBookRequest);
    }
}
