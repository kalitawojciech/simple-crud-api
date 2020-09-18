using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CRUD.Services.Services;
using CRUD.Services.Dtos.Books.Request;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooksService _booksService;

        public BooksController(IBooksService bookService)
        {
            _booksService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await _booksService.GetAllBooks();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var result = await _booksService.GetBookById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook([FromBody] AddBookRequest addBookRequest)
        {
            await _booksService.AddNewBook(addBookRequest);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBookById(Guid id)
        {
            await _booksService.RemoveBook(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditBook([FromBody] EditBookRequest editBookRequest)
        {
            await _booksService.EditBook(editBookRequest);

            return Ok();
        }
    }
}
