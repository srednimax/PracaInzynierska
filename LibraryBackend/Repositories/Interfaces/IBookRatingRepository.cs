using LibraryDatabase.Models;

namespace LibraryBackend.Repositories.Interfaces;

public interface IBookRatingRepository
{
    public Task<BookRating?> GetBookRatingById(int id);
    public Task<List<BookRating>> GetAllBooks();
    public Task<BookRating> AddBookRating(BookRating bookRating);
    public Task<BookRating> UpdateBookRating(BookRating bookRating);
    public Task<BookRating> RemoveBookRating(BookRating bookRating);
}