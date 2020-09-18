using AutoMapper;
using CRUD.DAL.Entities;
using CRUD.DAL.Repositories.Interfaces;
using CRUD.Services.Dtos.Authors.Response;
using CRUD.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorsRepository;

        public AuthorsService(IMapper mapper, IAuthorRepository authorsRepository)
        {
            _mapper = mapper;
            _authorsRepository = authorsRepository;
        }

        public async Task<List<AuthorInfoResponse>> GetAllAuthors()
        {
            List<Author> authorsFromDb = await _authorsRepository.GetAllAuthor();

            var authorsToReturn = _mapper.Map<List<AuthorInfoResponse>>(authorsFromDb);

            return authorsToReturn;
        }
    }
}
