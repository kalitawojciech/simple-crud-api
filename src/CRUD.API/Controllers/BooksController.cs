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
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bookService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _bookService.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody] AddBookRequest addBookRequest)
        {
            await _bookService.AddNew(addBookRequest);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _bookService.Remove(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditBookRequest editBookRequest)
        {
            await _bookService.Edit(editBookRequest);

            return Ok();
        }
    }
}
