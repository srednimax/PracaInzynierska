using LibraryBackend.Dtos.Book;
using LibraryBackend.Dtos.BorrowedBook;

namespace LibraryBackend.Services.Interfaces
{
    public interface IBorrowingBookService
    {
        public Task<ServiceResult<List<BorrowedBookDto>>> GetAllBorrowedBooks();
        public Task<ServiceResult<List<BorrowedBookDto>>> GetAllBorrowedBooksByUser(int userId);
        public Task<ServiceResult<BorrowedBookDto>> BorrowBook(BorrowedBookAddDto borrowedBookAddDto);
        public Task<ServiceResult<BorrowedBookDto>> ReturnBook(int bookId);
        public Task<ServiceResult<BorrowedBookDto>> OrderBook(int bookId);
        public Task<ServiceResult<BorrowedBookDto>> ChangeStatus();
    }
}
