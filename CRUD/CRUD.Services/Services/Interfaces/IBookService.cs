using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD.Services.Dtos.Books.Request;
using CRUD.Services.Dtos.Books.Response;

namespace CRUD.Services.Services
{
    public interface IBookService
    {
        public Task<List<BookFullInfoResponse>> GetAll();

        public Task<BookFullInfoResponse> GetById(Guid bookId);

        public Task AddNew(AddBookRequest addBookRequest);

        public Task Remove(Guid bookId);

        public Task Edit(EditBookRequest editBookRequest);
    }
}
