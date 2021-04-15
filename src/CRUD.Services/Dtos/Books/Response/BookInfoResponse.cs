using System;

namespace CRUD.Services.Dtos.Books.Response
{
    public class BookInfoResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public int PagesCount { get; set; }

        public Guid AuthorId { get; set; }
    }
}
