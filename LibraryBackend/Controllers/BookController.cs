﻿using LibraryBackend.Dtos.Book;
using LibraryBackend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<BookDto>>> GetAllBooks()
        {
            var result = await _bookService.GetAllBooks();

            return result.Status switch
            {
                200 => result.Body
            };
        }

        [Authorize(Roles = "Employee")]
        [HttpPost]
        public async Task<ActionResult<BookDto>> AddBook(BookAddDto bookAddDto)
        {
            var result = await _bookService.AddBook(bookAddDto);

            return result.Status switch
            {
                200 => result.Body,
                500 => Problem(result.Message)
            };
        }

        [Authorize(Roles = "Employee")]
        [HttpPut]
        public async Task<ActionResult<BookDto>> UpdateBook(BookUpdateDto bookUpdateDto)
        {
            var result = await _bookService.UpdateBook(bookUpdateDto);

            return result.Status switch
            {
                200 => result.Body,
                404 => NotFound(),
                500 => Problem(result.Message)
            };
        }

        [Authorize(Roles = "Employee")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookDto>> RemoveBook(int id)
        {
            var result = await _bookService.RemoveBook(id);

            return result.Status switch
            {
                200 => result.Body,
                404 => NotFound(),
                500 => Problem(result.Message)
            };
        }

        [Authorize(Roles = "User")]
        [HttpGet("Recommended")]
        public async Task<ActionResult<List<BookDto>>> GetRecommendedBooks()
        {
            var userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);

            var result = await _bookService.GetRecommendedBooks(userId);

            return result.Status switch
            {
                200 => result.Body,
                404 => NotFound(),
                500 => Problem(result.Message)
            };
        }
    }
}
