using System;
using System.Collections.Generic;

namespace CRUD.DAL.Entities
{
    public class Author
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
