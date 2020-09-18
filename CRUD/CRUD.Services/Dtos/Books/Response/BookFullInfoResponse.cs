using System;

using CRUD.Services.Dtos.Authors.Response;

namespace CRUD.Services.Dtos.Books.Response
{
    public class BookFullInfoResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public int PagesCount { get; set; }

        public Guid AuthorId { get; set; }

        public AuthorInfoResponse AuthorResponse { get; set; }
    }
}
