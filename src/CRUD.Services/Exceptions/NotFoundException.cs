using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Services.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {

        }

        public NotFoundException(string message) : base(message)
        {

        }
    }
}
