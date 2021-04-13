using System;
using System.Collections.Generic;

namespace CRUD.DAL.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
