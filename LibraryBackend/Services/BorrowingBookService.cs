using AutoMapper;
using LibraryBackend.Dtos.BorrowedBook;
using LibraryBackend.Repositories.Interfaces;
using LibraryBackend.Services.Interfaces;

namespace LibraryBackend.Services
{
    public class BorrowingBookService :IBorrowingBookService
    {
        private readonly IBorrowedBookRepository _borrowedBookRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BorrowingBookService(IBorrowedBookRepository borrowedBookRepository, IBookRepository bookRepository, IMapper mapper)
        {
            _borrowedBookRepository = borrowedBookRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<BorrowedBookDto>> GetAllBorrowedBooks(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<BorrowedBookDto>> BorrowBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<BorrowedBookDto>> ReturnBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<BorrowedBookDto>> OrderBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<BorrowedBookDto>> ChangeStatus()
        {
            throw new NotImplementedException();
        }
    }
}
