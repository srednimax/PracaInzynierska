using LibraryBackend.Dtos.Book;
using LibraryDatabase.Models;

namespace LibraryBackend.Services.Interfaces;

public interface IBookService
{
    public Task<ServiceResult<List<BookDto>>> GetAllBooks();
    public Task<ServiceResult<BookDto>> AddBook(BookAddDto bookAddDto);
    public Task<ServiceResult<BookDto>> UpdateBook(BookUpdateDto bookUpdateDto);
    public Task<ServiceResult<BookDto>> RemoveBook( int id);
    public Task<ServiceResult<List<BookDto>>> GetRecommendedBooks(int userId);
}