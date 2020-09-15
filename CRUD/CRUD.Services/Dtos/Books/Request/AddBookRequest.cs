using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Services.Dtos.Books.Request
{
    public class AddBookRequest
    {
        public string Title { get; set; }

        public int PagesCount { get; set; }
    }
}
