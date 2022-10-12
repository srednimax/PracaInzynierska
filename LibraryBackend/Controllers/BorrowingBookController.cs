using LibraryBackend.Dtos.Book;
using LibraryBackend.Dtos.BorrowedBook;
using LibraryBackend.Services.Interfaces;
using LibraryDatabase.Models;
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

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<ActionResult<BorrowedBookDto>> BorrowBook(int bookId)
        {
            var borrowedBookAddDto = new BorrowedBookAddDto()
            {
                BookId = bookId,
                UserId = int.Parse(User.Claims.First(x => x.Type == "id").Value)
            };

            var result = await _borrowingBookService.BorrowBook(borrowedBookAddDto);

            return result.Status switch
            {
                200 => result.Body,
                404 => NotFound(),
                500 => Problem(result.Message)
            };
        }

        [HttpGet]
        public async Task<ActionResult<List<BorrowedBookDto>>> GetAllBorrowedBooks()
        {
            var result =await  _borrowingBookService.GetAllBorrowedBooks();

            return result.Status switch
            {
                200 => result.Body
            };
        }
        [Authorize(Roles="User")]
        [HttpGet("UserBook's")]
        public async Task<ActionResult<List<BorrowedBookDto>>> GetAllBorrowedBooksByUser()
        {
            var userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);

            var result = await _borrowingBookService.GetAllBorrowedBooksByUser(userId);

            return result.Status switch
            {
                200 => result.Body
            };
        }
        [Authorize(Roles = "Employee")]
        [HttpPut("Return")]
        public async Task<ActionResult<BorrowedBookDto>> ReturnBook(BorrowedBookReturnDto borrowedBookReturnDto)
        {
            var result = await _borrowingBookService.ReturnBook(borrowedBookReturnDto);

            return result.Status switch
            {
                200 => result.Body,
                404 => NotFound(),
                500 => Problem(result.Message)
            };
        }

        [HttpPut("Renew")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<BorrowedBookDto>> RenewBook(int borrowedBookId)
        {
            var result = await _borrowingBookService.RenewBook(borrowedBookId);

            return result.Status switch
            {
                200 => result.Body,
                404 => NotFound(),
                500 => Problem(result.Message)
            };
        }
        [HttpPut("ChangeStatus")]
        [Authorize(Roles = "Employee")]
        public async Task<ActionResult<BorrowedBookDto>> ChangeStatus(BorrowedBookChangeStatusDto bookChangeStatusDto)
        {
            var result = await _borrowingBookService.ChangeStatus(bookChangeStatusDto);

            return result.Status switch
            {
                200 => result.Body,
                404 => NotFound(),
                500 => Problem(result.Message)
            };
        }
    }
}
