using CRUD.Services.Dtos.Authors.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Services.Interfaces
{
    public interface IAuthorsService
    {
        public Task<List<AuthorInfoResponse>> GetAllAuthors();
    }
}
