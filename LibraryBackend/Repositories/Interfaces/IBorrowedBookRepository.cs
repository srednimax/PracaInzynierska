using LibraryDatabase.Models;

namespace LibraryBackend.Repositories.Interfaces;

public interface IBorrowedBookRepository
{
    public Task<List<BorrowedBook>> GetAllBorrowedBooks();
    public Task<BorrowedBook?> GetBorrowedBookById(int id);
    public Task<bool> CheckIfUserBookedBook(int bookId,int userId);
    public Task<List<BorrowedBook>> GetBorrowedBooksByUser(int userId);
    public Task<BorrowedBook?> GetBorrowedBookByUser(int userId,int bookId);
    public Task<BorrowedBook> AddBorrowedBook(BorrowedBook borrowedBook);
    public Task<BorrowedBook> UpdateBorrowedBook(BorrowedBook borrowedBook);
    public Task<bool> MoreThanThreeBooks(int userId);
}