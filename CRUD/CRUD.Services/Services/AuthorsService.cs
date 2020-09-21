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
    public class AuthorsService : IAuthorsService
    {
        private readonly IMapper _mapper;
        private readonly IAuthorsRepository _authorsRepository;

        public AuthorsService(IMapper mapper, IAuthorsRepository authorsRepository)
        {
            _mapper = mapper;
            _authorsRepository = authorsRepository;
        }

        public async Task AddNewAuthor(AddAuthorRequest addAuthorRequest)
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

            await _authorsRepository.AddNewAuthor(author);
        }

        public async Task<List<AuthorFullInfoResponse>> GetAllAuthors()
        {
            List<Author> authorsFromDb = await _authorsRepository.GetAllAuthor();

            var authorsToReturn = _mapper.Map<List<AuthorFullInfoResponse>>(authorsFromDb);

            return authorsToReturn;
        }

        public async Task<AuthorFullInfoResponse> GetAuthorById(Guid id)
        {
            Author authorFromDb = await _authorsRepository.GetAuthorById(id);

            var authorToReturn = _mapper.Map<AuthorFullInfoResponse>(authorFromDb);

            return authorToReturn;
        }

        public async Task RemoveAuthor(Guid id)
        {
            Author author = await _authorsRepository.GetAuthorById(id);

            if(author == null)
            {
                throw new BadRequestException("Nie istnieje taki autor");
            }

            if(author.Books.Count > 0 )
            {
                throw new BadRequestException("Autor ma przypisane książki");
            }

            _authorsRepository.RemoveAuthor(author);
        }
    }
}
