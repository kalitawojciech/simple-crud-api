using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Services.Dtos.Authors.Request
{
    public class AddAuthorRequest
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
