using LibraryDatabase.Models;

namespace LibraryBackend.Repositories.Interfaces;

public interface IBorrowedBookRepository
{
    public Task<List<BorrowedBook>> GetAllBorrowedBooks();
    public Task<BorrowedBook?> GetBorrowedBooksById(int id);
    public Task<List<BorrowedBook>> GetBorrowedBooksByUser(int userId);
    public Task<BorrowedBook> AddBorrowedBook(BorrowedBook borrowedBook);
    public Task<BorrowedBook> UpdateBorrowedBook(BorrowedBook borrowedBook);
}