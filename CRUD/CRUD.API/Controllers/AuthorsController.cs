using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUD.Services.Services.Interfaces;
using System;
using CRUD.Services.Dtos.Authors.Request;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var result = await _authorsService.GetAllAuthors();

            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetAuthorById(Guid id)
        {
            var result = await _authorsService.GetAuthorById(id);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAuthor(Guid id)
        {
            await _authorsService.RemoveAuthor(id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewAuthor([FromBody] AddAuthorRequest addAuthorRequest)
        {
            await _authorsService.AddNewAuthor(addAuthorRequest);

            return Ok();
        }
    }
}
