using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD.Services.Dtos.Authors.Request;
using CRUD.Services.Dtos.Authors.Response;

namespace CRUD.Services.Services.Interfaces
{
    public interface IAuthorsService
    {
        public Task<List<AuthorFullInfoResponse>> GetAllAuthors();

        public Task<AuthorFullInfoResponse> GetAuthorById(Guid id);

        public Task RemoveAuthor(Guid id);

        public Task AddNewAuthor(AddAuthorRequest addAuthorRequest);
    }
}
