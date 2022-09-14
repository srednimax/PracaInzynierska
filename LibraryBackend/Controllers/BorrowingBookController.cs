using LibraryBackend.Dtos.Book;
using LibraryBackend.Dtos.BorrowedBook;
using LibraryBackend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingBookController : ControllerBase
    {
        private readonly IBorrowingBookService _borrowingBookService;

        public BorrowingBookController(IBorrowingBookService borrowingBookService)
        {
            _borrowingBookService = borrowingBookService;
        }

        [AllowAnonymous]
        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<ActionResult<BorrowedBookDto>> BorrowBook(BorrowedBookAddDto borrowedBookAddDto)
        {
            borrowedBookAddDto.UserId = int.Parse(User.Claims.First(x => x.Type == "id").Value);

            var result = await _borrowingBookService.BorrowBook(borrowedBookAddDto);

            return result.Status switch
            {
                200 => result.Body,
                404 => NotFound(),
                500 => Problem(result.Message)
            };
        }
    }
}
