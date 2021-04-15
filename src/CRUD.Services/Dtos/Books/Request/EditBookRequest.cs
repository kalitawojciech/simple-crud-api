using System;

namespace CRUD.Services.Dtos.Books.Request
{
    public class EditBookRequest
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public int PagesCount { get; set; }
    }
}
