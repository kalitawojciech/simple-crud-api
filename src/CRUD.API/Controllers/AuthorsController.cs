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
        private IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _authorService.GetAll();

            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _authorService.GetById(id);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _authorService.Remove(id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody] AddAuthorRequest addAuthorRequest)
        {
            await _authorService.AddNew(addAuthorRequest);

            return Ok();
        }
    }
}
