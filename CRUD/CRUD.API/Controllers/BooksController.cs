using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CRUD.Services.Services;

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
    }
}
