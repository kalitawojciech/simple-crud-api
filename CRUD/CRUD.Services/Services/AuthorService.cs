using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using CRUD.DAL.Entities;
using CRUD.DAL.Repositories.Interfaces;
using CRUD.Services.Dtos.Authors.Request;
using CRUD.Services.Dtos.Authors.Response;
using CRUD.Services.Exceptions;
using CRUD.Services.Services.Interfaces;

namespace CRUD.Services.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IMapper mapper, IAuthorRepository authorRepository)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        public async Task AddNew(AddAuthorRequest addAuthorRequest)
        {
            if(addAuthorRequest.Name == null)
            {
                throw new BadRequestException("Imie jest puste");
            }

            if(addAuthorRequest.Age < 0)
            {
                throw new BadRequestException("Chłop się jeszcze nie urodził");
            }

            Author author = new Author()
            {
                Id = Guid.NewGuid(),
                Name = addAuthorRequest.Name,
                Age = addAuthorRequest.Age
            };

            await _authorRepository.AddNew(author);
        }

        public async Task<List<AuthorFullInfoResponse>> GetAll()
        {
            List<Author> authorsFromDb = await _authorRepository.GetAll();

            var authorsToReturn = _mapper.Map<List<AuthorFullInfoResponse>>(authorsFromDb);

            return authorsToReturn;
        }

        public async Task<AuthorFullInfoResponse> GetById(Guid id)
        {
            Author authorFromDb = await _authorRepository.GetById(id);

            var authorToReturn = _mapper.Map<AuthorFullInfoResponse>(authorFromDb);

            return authorToReturn;
        }

        public async Task Remove(Guid id)
        {
            Author author = await _authorRepository.GetById(id);

            if(author == null)
            {
                throw new BadRequestException("Nie istnieje taki autor");
            }

            if(author.Books.Count > 0 )
            {
                throw new BadRequestException("Autor ma przypisane książki");
            }

            _authorRepository.Remove(author);
        }
    }
}
