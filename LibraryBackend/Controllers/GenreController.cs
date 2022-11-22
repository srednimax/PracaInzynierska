using LibraryBackend.Dtos.Genre;
using LibraryBackend.Dtos.User;
using LibraryBackend.Services.Interfaces;
using LibraryDatabase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [AllowAnonymous]
        [HttpGet("All")]
        public async Task<ActionResult<List<GenreDto>>> GetAllGenres()
        {
            var result = await _genreService.GetAllGenres();
            switch (result.Status)
            {
                case 200:
                    return result.Body;
                case 500:
                    return Problem(result.Message);
                default:
                    return BadRequest();
            }
        }

        [Authorize(Roles="Employee")]
        [HttpPost]
        public async Task<ActionResult<GenreDto>> AddGenre( GenreAddDto genreAddDto)
        {
            var result = await _genreService.AddGenre(genreAddDto);
            switch (result.Status)
            {
                case 200:
                    return result.Body;
                case 500:
                    return Problem(result.Message);
                default:
                    return BadRequest();
            }
        }

        [Authorize(Roles = "Employee")]
        [HttpPut]
        public async Task<ActionResult<GenreDto>> UpdateGenre(GenreUpdateDto genreAddDto)
        {
            var result = await _genreService.UpdateGenre(genreAddDto);
            switch (result.Status)
            {
                case 200:
                    return result.Body;
                case 500:
                    return Problem(result.Message);
                default:
                    return BadRequest();
            }
        }

        [Authorize(Roles = "Employee")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<GenreDto>> DeleteGenre(int id)
        {
            var result = await _genreService.RemoveGenre(id);
            switch (result.Status)
            {
                case 200:
                    return result.Body;
                case 500:
                    return Problem(result.Message);
                default:
                    return BadRequest();
            }
        }

    }
}
