using AutoMapper;

using CRUD.DAL.Entities;
using CRUD.Services.Dtos.Authors.Response;
using CRUD.Services.Dtos.Books.Response;

namespace CRUD.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookInfoResponse>()
                .ForMember(x => x.AuthorResponse, opt => opt.MapFrom(y => y.Author));

            CreateMap<Author, AuthorInfoResponse>();
        }
    }
}
