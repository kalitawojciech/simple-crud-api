﻿using System;

namespace CRUD.Services.Dtos.Books.Request
{
    public class AddBookRequest
    {
        public string Title { get; set; }

        public int PagesCount { get; set; }

        public Guid AuthorId { get; set; }
    }
}
