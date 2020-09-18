﻿using System;
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
    public class BooksService : IBooksService
    {
        private readonly IMapper _mapper;
        private readonly IBooksRepository _booksRepository;
        public BooksService(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        public async Task AddNewBook(AddBookRequest addBookRequest)
        {
            if(string.IsNullOrEmpty(addBookRequest.Title))
            {
                throw new BadRequestException("Błędna nazwa!!");
            }

            if(addBookRequest.PagesCount < 1)
            {
                throw new BadRequestException("Błędna liczba stron!!");
            }

            if((await _booksRepository.GetBookByTitle(addBookRequest.Title)) != null)
            {
                throw new BadRequestException("Ten tytuł został już użyty!!");
            }

            Book bookToAdd = new Book
            {
                Id = Guid.NewGuid(),
                Title = addBookRequest.Title,
                PagesCount = addBookRequest.PagesCount
            };

            await _booksRepository.AddNewBook(bookToAdd);
        }

        public async Task<List<BookFullInfoResponse>> GetAllBooks()
        {
            List<Book> booksFromDb = await _booksRepository.GetAllBooks();

            var booksToReturn = _mapper.Map<List<BookFullInfoResponse>>(booksFromDb);

            return booksToReturn;
        }

        public async Task<BookFullInfoResponse> GetBookById(Guid bookId)
        {
            Book bookFromDb = await _booksRepository.GetBookById(bookId);

            var bookToReturn = _mapper.Map<BookFullInfoResponse>(bookFromDb);

            return bookToReturn;
        }

        public async Task RemoveBook(Guid bookId)
        {
            Book bookFromDb = await _booksRepository.GetBookById(bookId);

            if (bookFromDb == null)
            {
                throw new BadRequestException("Nie istnieje taka książka!!");
            }

            _booksRepository.RemoveBook(bookFromDb);
        }

        public async Task EditBook(EditBookRequest editBookRequest)
        {
            Book bookFromDb = await _booksRepository.GetBookById(editBookRequest.Id);

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
                if ((await _booksRepository.GetBookByTitle(editBookRequest.Title)) != null)
                {
                    throw new BadRequestException("Ten tytuł został już użyty!!");
                }
            }

            bookFromDb.Title = editBookRequest.Title;
            bookFromDb.PagesCount = editBookRequest.PagesCount;

            await _booksRepository.SaveChanges();
        }
    }
}
