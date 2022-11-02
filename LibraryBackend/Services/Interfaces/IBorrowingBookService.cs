using LibraryBackend.Dtos.Book;
using LibraryBackend.Dtos.BorrowedBook;

namespace LibraryBackend.Services.Interfaces
{
    public interface IBorrowingBookService
    {
        public Task<ServiceResult<List<BorrowedBookDto>>> GetAllBorrowedBooks();
        public Task<ServiceResult<List<BorrowedBookDto>>> GetAllBorrowedBooksByUser(int userId);
        public Task<ServiceResult<BorrowedBookDto>> BorrowBook(BorrowedBookAddDto borrowedBookAddDto);
        public Task<ServiceResult<BorrowedBookDto>> ReturnBook(BorrowedBookReturnDto borrowedBookReturnDto);
        public Task<ServiceResult<BorrowedBookDto>> RenewBook(int borrowedBookId);
        public Task<ServiceResult<BorrowedBookDto>> ChangeStatus(BorrowedBookChangeStatusDto bookChangeStatusDto);
        public Task<ServiceResult<BorrowedBookDto>> Cancel(int borrowedBookId);
    }
}
