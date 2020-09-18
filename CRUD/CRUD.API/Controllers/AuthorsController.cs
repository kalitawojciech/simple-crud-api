using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUD.Services.Services.Interfaces;

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
    }
}
