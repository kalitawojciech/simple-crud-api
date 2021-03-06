﻿using System;

namespace CRUD.DAL.Entities
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public int PagesCount { get; set; }

        public Guid AuthorId { get; set; }

        public Author Author { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
