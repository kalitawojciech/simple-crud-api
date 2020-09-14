using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using CRUD.DAL.Entities;
using CRUD.DAL.Repositories.Interfaces;
using CRUD.Services.Dtos.Books.Response;

namespace CRUD.Services.Services
{
    public class BooksService : IBooksService
    {
        private readonly IMapper _mapper;
        private readonly IBooksRepository _booksRepository;
        public BooksService(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        public async Task<List<BookInfoResponse>> GetAllBooks()
        {
            List<Book> booksFromDb = await _booksRepository.GetAllBooks();

            var booksToReturn = _mapper.Map<List<BookInfoResponse>>(booksFromDb);

            return booksToReturn;
        }
    }
}
