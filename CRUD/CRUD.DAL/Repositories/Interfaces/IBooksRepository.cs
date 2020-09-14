using System.Collections.Generic;
using System.Threading.Tasks;

using CRUD.DAL.Entities;

namespace CRUD.DAL.Repositories.Interfaces
{
    public interface IBooksRepository
    {
        public Task<List<Book>> GetAllBooks();
    }
}
