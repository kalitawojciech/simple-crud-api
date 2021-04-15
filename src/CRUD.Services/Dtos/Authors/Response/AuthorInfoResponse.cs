using System;

namespace CRUD.Services.Dtos.Authors.Response
{
    public class AuthorInfoResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
