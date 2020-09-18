using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using CRUD.DAL.Entities;
using CRUD.DAL.Repositories.Interfaces;
using CRUD.Services.Dtos.Authors.Response;
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

        public async Task<List<AuthorFullInfoResponse>> GetAllAuthors()
        {
            List<Author> authorsFromDb = await _authorsRepository.GetAllAuthor();

            var authorsToReturn = _mapper.Map<List<AuthorFullInfoResponse>>(authorsFromDb);

            return authorsToReturn;
        }
    }
}
