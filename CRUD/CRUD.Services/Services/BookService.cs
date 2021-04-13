using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CRUD.DAL.Entities;
using CRUD.DAL.Repositories.Interfaces;
using CRUD.Services.Dtos.Books.Request;
using CRUD.Services.Dtos.Books.Response;
using CRUD.Services.Exceptions;

namespace CRUD.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task AddNew(AddBookRequest addBookRequest)
        {
            if(string.IsNullOrEmpty(addBookRequest.Title))
            {
                throw new BadRequestException("Błędna nazwa!!");
            }

            if(addBookRequest.PagesCount < 1)
            {
                throw new BadRequestException("Błędna liczba stron!!");
            }

            if((await _bookRepository.GetByTitle(addBookRequest.Title)) != null)
            {
                throw new BadRequestException("Ten tytuł został już użyty!!");
            }

            if ((await _authorRepository.GetById(addBookRequest.AuthorId)) == null)
            {
                throw new BadRequestException("Nie ma takiego autora!");
            }

            Book bookToAdd = new Book
            {
                Id = Guid.NewGuid(),
                Title = addBookRequest.Title,
                PagesCount = addBookRequest.PagesCount
            };

            await _bookRepository.AddNew(bookToAdd);
        }

        public async Task<List<BookFullInfoResponse>> GetAll()
        {
            List<Book> booksFromDb = await _bookRepository.GetAll();

            var booksToReturn = _mapper.Map<List<BookFullInfoResponse>>(booksFromDb);

            return booksToReturn;
        }

        public async Task<BookFullInfoResponse> GetById(Guid bookId)
        {
            Book bookFromDb = await _bookRepository.GetById(bookId);

            var bookToReturn = _mapper.Map<BookFullInfoResponse>(bookFromDb);

            return bookToReturn;
        }

        public async Task Remove(Guid bookId)
        {
            Book bookFromDb = await _bookRepository.GetById(bookId);

            if (bookFromDb == null)
            {
                throw new BadRequestException("Nie istnieje taka książka!!");
            }

            _bookRepository.Remove(bookFromDb);
        }

        public async Task Edit(EditBookRequest editBookRequest)
        {
            Book bookFromDb = await _bookRepository.GetById(editBookRequest.Id);

            if (bookFromDb == null)
            {
                throw new BadRequestException("Nie istnieje taka książka!!");
            }

            if (string.IsNullOrEmpty(editBookRequest.Title))
            {
                throw new BadRequestException("Błędna nazwa!!");
            }

            if (editBookRequest.PagesCount < 1)
            {
                throw new BadRequestException("Błędna liczba stron!!");
            }

            if(editBookRequest.Title.ToLower() != bookFromDb.Title.ToLower())
            {
                if ((await _bookRepository.GetByTitle(editBookRequest.Title)) != null)
                {
                    throw new BadRequestException("Ten tytuł został już użyty!!");
                }
            }

            bookFromDb.Title = editBookRequest.Title;
            bookFromDb.PagesCount = editBookRequest.PagesCount;

            await _bookRepository.SaveChanges();
        }
    }
}
