using LibraryBackend.Dtos.Book;
using LibraryBackend.Dtos.BorrowedBook;

namespace LibraryBackend.Services.Interfaces
{
    public interface IBorrowingBookService
    {
        public Task<ServiceResult<BorrowedBookDto>> GetAllBorrowedBooks(int userId);
        public Task<ServiceResult<BorrowedBookDto>> BorrowBook(int bookId);
        public Task<ServiceResult<BorrowedBookDto>> ReturnBook(int bookId);
        public Task<ServiceResult<BorrowedBookDto>> OrderBook(int bookId);
        public Task<ServiceResult<BorrowedBookDto>> ChangeStatus();
    }
}
