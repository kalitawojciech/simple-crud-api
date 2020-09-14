using System;

namespace CRUD.DAL.Entities
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public int PagesCount { get; set; }
    }
}
