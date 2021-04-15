using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD.Services.Dtos.Authors.Request;
using CRUD.Services.Dtos.Authors.Response;

namespace CRUD.Services.Services.Interfaces
{
    public interface IAuthorService
    {
        public Task<List<AuthorFullInfoResponse>> GetAll();

        public Task<AuthorFullInfoResponse> GetById(Guid id);

        public Task Remove(Guid id);

        public Task AddNew(AddAuthorRequest addAuthorRequest);
    }
}
