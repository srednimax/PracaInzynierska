using LibraryDatabase.Models;

namespace LibraryBackend.Repositories.Interfaces;

public interface IBookRatingRepository
{
    public Task<BookRating?> GetBookRatingById(int id);
    public Task<List<BookRating>> GetAllBooks();
    public Task<List<BookRating>> GetAllBookRatingsByUser(int userId);
    public Task<List<BookRating>> GetAllBookRatingsByBook(int bookId);
    public Task<BookRating> AddBookRating(BookRating bookRating);
    public Task<BookRating> UpdateBookRating(BookRating bookRating);
    public Task<BookRating> RemoveBookRating(BookRating bookRating);
    public Task<float> CalculateRating(int bookId);
}