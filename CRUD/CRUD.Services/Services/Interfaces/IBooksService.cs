using System.Collections.Generic;
using System.Threading.Tasks;

using CRUD.Services.Dtos.Books.Response;

namespace CRUD.Services.Services
{
    public interface IBooksService
    {
        public Task<List<BookInfoResponse>> GetAllBooks();
    }
}
