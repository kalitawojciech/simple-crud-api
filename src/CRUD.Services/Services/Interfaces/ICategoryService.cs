using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD.Services.Dtos.Categories.Response;

namespace CRUD.Services.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryFullInfoResponse>> GetAll();

        Task<CategoryFullInfoResponse> GetById(Guid id);
    }
}
