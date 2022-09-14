using AutoMapper;
using LibraryBackend.Dtos.BorrowedBook;
using LibraryBackend.Repositories.Interfaces;
using LibraryBackend.Services.Interfaces;
using LibraryDatabase.Models;

namespace LibraryBackend.Services
{
    public class BorrowingBookService :IBorrowingBookService
    {
        private readonly IBorrowedBookRepository _borrowedBookRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public BorrowingBookService(IBorrowedBookRepository borrowedBookRepository, IBookRepository bookRepository, IUserRepository userRepository, IMapper mapper)
        {
            _borrowedBookRepository = borrowedBookRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<BorrowedBookDto>>> GetAllBorrowedBooks()
        {
            return new ServiceResult<List<BorrowedBookDto>>()
            {
                Body = _mapper.Map<List<BorrowedBookDto>>(await _borrowedBookRepository.GetAllBorrowedBooks()),
                Status = 200
            };
        }

        public async Task<ServiceResult<List<BorrowedBookDto>>> GetAllBorrowedBooksByUser(int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user is null)
                return new ServiceResult<List<BorrowedBookDto>>() { Status = 404 };

            var borrowedBooks = await _borrowedBookRepository.GetBorrowedBooksByUser(userId);

            return new ServiceResult<List<BorrowedBookDto>>()
            {
                Body = _mapper.Map<List<BorrowedBookDto>>(borrowedBooks),
                Status = 200
            };
        }

        public async Task<ServiceResult<BorrowedBookDto>> BorrowBook(BorrowedBookAddDto borrowedBookAddDto)
        {
            var user = await _userRepository.GetUserById(borrowedBookAddDto.UserId);

            if (user is null)
                return new ServiceResult<BorrowedBookDto>() { Status = 404 };

            var book = await _bookRepository.GetBookById(borrowedBookAddDto.BookId);

            if (book is null)
                return new ServiceResult<BorrowedBookDto>() { Status = 404 };

            var borrowedBook = new BorrowedBook()
            {
                Book = book,
                Reader = user
            };

            if (book.IsBorrowed)
            {
                borrowedBook.Status = Status.WaitingForBook;
                return new ServiceResult<BorrowedBookDto>()
                {
                    Body = _mapper.Map<BorrowedBookDto>(await _borrowedBookRepository.AddBorrowedBook(borrowedBook)),
                    Status = 200
                };
            }

            book.IsBorrowed = true;
            await _bookRepository.UpdateBook(book);

            return new ServiceResult<BorrowedBookDto>()
            {
                Body = _mapper.Map<BorrowedBookDto>(await _borrowedBookRepository.AddBorrowedBook(borrowedBook)),
                Status = 200
            };



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
