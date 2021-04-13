using CRUD.Services.Dtos.Books.Response;
using System;
using System.Collections.Generic;

namespace CRUD.Services.Dtos.Categories.Response
{
    public class CategoryFullInfoResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public ICollection<BookFullInfoResponse> BooksResponse { get; set; }
    }
}
