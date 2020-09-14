using AutoMapper;

using CRUD.DAL.Entities;
using CRUD.Services.Dtos.Books.Response;

namespace CRUD.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookInfoResponse>();
        }
    }
}
