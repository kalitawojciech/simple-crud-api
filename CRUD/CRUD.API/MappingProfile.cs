using AutoMapper;

using CRUD.DAL.Entities;
using CRUD.Services.Dtos.Authors.Response;
using CRUD.Services.Dtos.Books.Response;
using CRUD.Services.Dtos.Categories.Response;

namespace CRUD.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookFullInfoResponse>()
                .ForMember(x => x.AuthorResponse, opt => opt.MapFrom(y => y.Author));

            CreateMap<Book, BookInfoResponse>();

            CreateMap<Author, AuthorFullInfoResponse>()
                .ForMember(x => x.BooksResponse, opt => opt.MapFrom(y => y.Books));

            CreateMap<Author, AuthorInfoResponse>();

            CreateMap<Category, CategoryFullInfoResponse>()
                .ForMember(x => x.BooksResponse, opt => opt.MapFrom(y => y.Books));
        }
    }
}
