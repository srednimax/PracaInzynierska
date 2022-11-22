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

            if (user.Penalty > 0)
                return new ServiceResult<BorrowedBookDto>()
                    { Status = 500, Message = "You must first pay the penalty" };

            var book = await _bookRepository.GetBookById(borrowedBookAddDto.BookId);

            if (book is null)
                return new ServiceResult<BorrowedBookDto>() { Status = 404 };

            if (await _borrowedBookRepository.CheckIfUserBookedBook(borrowedBookAddDto.BookId,
                    borrowedBookAddDto.UserId))
            {
                return new ServiceResult<BorrowedBookDto>() { Status = 500, Message="You already booked this book" };
            }

            if (await _borrowedBookRepository.MoreThanThreeBooks(user.Id))
            {
                return new ServiceResult<BorrowedBookDto>() { Status = 500, Message = "You can't borrowed more than 3 books at the same time" };
            }

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

        public async Task<ServiceResult<BorrowedBookDto>> ReturnBook(BorrowedBookReturnDto borrowedBookReturnDto)
        {
            var user = await _userRepository.GetUserById(borrowedBookReturnDto.EmployeeId);

            if (user is null)
                return new ServiceResult<BorrowedBookDto>() { Status = 404 };

            var borrowedBook = await _borrowedBookRepository.GetBorrowedBookById(borrowedBookReturnDto.BorrowedBookId);

            if (borrowedBook is null)
                return new ServiceResult<BorrowedBookDto>() { Status = 404 };

            var book = await _bookRepository.GetBookById(borrowedBook.Book.Id);

            if (book.IsBorrowed == false)
            {
                return new ServiceResult<BorrowedBookDto>()
                    { Status = 500, Message = "This book was already returned" };
            }

            if (borrowedBook.Status != Status.Received)
                return new ServiceResult<BorrowedBookDto>()
                {
                    Status = 500,
                    Message = "This book has not been received yet"
                };

                if (borrowedBook.ReturnDate < DateTime.Now)
            {
                user.Penalty += 10;
                await _userRepository.UpdateUser(user);
            }

            book.IsBorrowed = false;
            await _bookRepository.UpdateBook(book);

            borrowedBook.IsReturned = true;
            borrowedBook.Status = Status.Returned;
            borrowedBook.ReturnedDate = DateTime.Now;
            await _borrowedBookRepository.UpdateBorrowedBook(borrowedBook);

            return new ServiceResult<BorrowedBookDto>()
            {
                Body = _mapper.Map<BorrowedBookDto>(borrowedBook),
                Status = 200
            };
        }

        public async Task<ServiceResult<BorrowedBookDto>> RenewBook(int borrowedBookId)
        {
            var borrowedBook = await _borrowedBookRepository.GetBorrowedBookById(borrowedBookId);

            if (borrowedBook is null)
                return new ServiceResult<BorrowedBookDto>() { Status = 404 };

            if (borrowedBook.IsRenew)
                return new ServiceResult<BorrowedBookDto>() { Status = 500, Message = "This was already renewed" };

            if (borrowedBook.Status != Status.Ready)
                return new ServiceResult<BorrowedBookDto>() { Status = 500, Message =  "This book is not ready yet" };

            borrowedBook.ReturnDate = borrowedBook.ReturnDate.Value.AddDays(14);
            borrowedBook.IsRenew = true;

            await _borrowedBookRepository.UpdateBorrowedBook(borrowedBook);

            return new ServiceResult<BorrowedBookDto>()
            {
                Body = _mapper.Map<BorrowedBookDto>(borrowedBook),
                Status = 200
            };
        }


        public async Task<ServiceResult<BorrowedBookDto>> ChangeStatus(BorrowedBookChangeStatusDto bookChangeStatusDto)
        {
            var employee = await _userRepository.GetUserById(bookChangeStatusDto.EmployeeId);

            if (employee is null)
                return new ServiceResult<BorrowedBookDto>() { Status = 404 };

            var borrowedBook = await _borrowedBookRepository.GetBorrowedBookById(bookChangeStatusDto.BorrowedBookId);

            if (borrowedBook is null)
                return new ServiceResult<BorrowedBookDto>() { Status = 404 };

            if (borrowedBook.IsReturned)
                return new ServiceResult<BorrowedBookDto>()
                    { Status = 500, Message = "Can't change returned book's status" };

            borrowedBook.Status = bookChangeStatusDto.Status;
            borrowedBook.Employee = employee;

            if(bookChangeStatusDto.Status == Status.Ready)
                borrowedBook.ReturnDate = DateTime.Now.AddDays(14);

            return new ServiceResult<BorrowedBookDto>()
            {
                Body = _mapper.Map<BorrowedBookDto>(await _borrowedBookRepository.UpdateBorrowedBook(borrowedBook)),
                Status = 200
            };
        }

        public async Task<ServiceResult<BorrowedBookDto>> Cancel(int borrowedBookId)
        {
            var borrowedBook = await _borrowedBookRepository.GetBorrowedBookById(borrowedBookId);

            if (borrowedBook is null)
                return new ServiceResult<BorrowedBookDto>() { Status = 404 };

            if (borrowedBook.Status.GetHashCode() > 3)
                return new ServiceResult<BorrowedBookDto>() { Status = 500, Message = "You can't cancel" };

            borrowedBook.Status = Status.Cancel;

            return new ServiceResult<BorrowedBookDto>()
            {
                Status = 200,
                Body = _mapper.Map<BorrowedBookDto>(await _borrowedBookRepository.UpdateBorrowedBook(borrowedBook))
            };


        }
    }
}
