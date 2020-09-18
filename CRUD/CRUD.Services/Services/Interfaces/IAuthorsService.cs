using System.Collections.Generic;
using System.Threading.Tasks;

using CRUD.Services.Dtos.Authors.Response;

namespace CRUD.Services.Services.Interfaces
{
    public interface IAuthorsService
    {
        public Task<List<AuthorFullInfoResponse>> GetAllAuthors();
    }
}
