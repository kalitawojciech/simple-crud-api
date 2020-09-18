using System;
using System.Collections.Generic;

using CRUD.Services.Dtos.Books.Response;

namespace CRUD.Services.Dtos.Authors.Response
{
    public class AuthorFullInfoResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public ICollection<BookInfoResponse> BooksResponse { get; set; }
    }
}
