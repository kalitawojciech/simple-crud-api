using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CRUD.DAL.Entities;

namespace CRUD.DAL.Repositories.Interfaces
{
    public interface IAuthorsRepository
    {
        public Task<List<Author>> GetAllAuthor();
    }
}
