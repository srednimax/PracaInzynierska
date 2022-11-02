using LibraryBackend.Dtos.RatingBook;
using LibraryBackend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBackend.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles="User")]
    [ApiController]
    public class BookRatingController : ControllerBase
    {
        private readonly IBookRatingService _bookRatingService;

        public BookRatingController(IBookRatingService bookRatingService)
        {
            _bookRatingService = bookRatingService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BookRatingDto>> GetBookRatingById(int id )
        {

            var result = await _bookRatingService.GetBookRatingById(id);

            return result.Status switch
            {
                200 => result.Body,
                404 => NotFound(),
                500 => Problem(result.Message)
            };
        }

        [HttpGet("Users's")]
        public async Task<ActionResult<BookRatingDto>> GetBookRatingByUser()
        {
            var userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);

            var result = await _bookRatingService.GetBookRatingById(userId);

            return result.Status switch
            {
                200 => result.Body,
                404 => NotFound(),
                500 => Problem(result.Message)
            };
        }

        [HttpPost]
        public async Task<ActionResult<BookRatingDto>> AddBookRating(BookRatingAddDto bookRatingAddDto)
        {

            bookRatingAddDto.UserId = int.Parse(User.Claims.First(x => x.Type == "id").Value);

            var result = await _bookRatingService.AddBookRating(bookRatingAddDto);

            return result.Status switch
            {
                200 => result.Body,
                404 => NotFound(),
                500 => Problem(result.Message)
            };
        }

        [HttpPut]
        public async Task<ActionResult<BookRatingDto>> UpdateBookRating(BookRatingUpdateDto bookRatingUpdateDto)
        {

            bookRatingUpdateDto.UserId = int.Parse(User.Claims.First(x => x.Type == "id").Value);

            var result = await _bookRatingService.UpdateBookRating(bookRatingUpdateDto);

            return result.Status switch
            {
                200 => result.Body,
                404 => NotFound(),
                500 => Problem(result.Message)
            };
        }

        [HttpDelete]
        public async Task<ActionResult<BookRatingDto>> DeleteBookRating(BookRatingRemoveDto bookRatingRemoveDto)
        {

            bookRatingRemoveDto.UserId = int.Parse(User.Claims.First(x => x.Type == "id").Value);

            var result = await _bookRatingService.RemoveBookRating(bookRatingRemoveDto);

            return result.Status switch
            {
                200 => result.Body,
                404 => NotFound(),
                500 => Problem(result.Message)
            };
        }
    }
}
