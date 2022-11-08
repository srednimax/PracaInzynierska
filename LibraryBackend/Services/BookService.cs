using AutoMapper;
using LibraryBackend.Dtos.Book;
using LibraryBackend.Repositories.Interfaces;
using LibraryBackend.Services.Interfaces;
using LibraryDatabase.Models;

namespace LibraryBackend.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IBorrowedBookRepository _borrowedBookRepository;
    private readonly IUserRepository _userRepository;
    private readonly IBookRatingRepository _bookRatingRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IBorrowedBookRepository borrowedBookRepository, IUserRepository userRepository, IBookRatingRepository bookRatingRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _borrowedBookRepository = borrowedBookRepository;
        _userRepository = userRepository;
        _bookRatingRepository = bookRatingRepository;
        _mapper = mapper;
    }
    public async Task<ServiceResult<List<BookDto>>> GetAllBooks()
    {
        return new ServiceResult<List<BookDto>>()
        {
            Body = _mapper.Map<List<BookDto>>(await _bookRepository.GetAllBooks()),
            Status = 200
        };
    }

    public async Task<ServiceResult<BookDto>> AddBook(BookAddDto bookAddDto)
    {
        var bookToAdd = _mapper.Map<Book>(bookAddDto);

        return new ServiceResult<BookDto>()
        {
            Body = _mapper.Map<BookDto>(await _bookRepository.AddBook(bookToAdd)),
            Status = 200
        };
    }

    public async Task<ServiceResult<BookDto>> UpdateBook(BookUpdateDto bookUpdateDto)
    {
        var bookToUpdate = await _bookRepository.GetBookById(bookUpdateDto.Id);

        if (bookToUpdate == null)
            return new ServiceResult<BookDto>() { Status = 404 };

        if (bookToUpdate.IsBorrowed)
            return new ServiceResult<BookDto>() { Status = 500, Message = "Can't update borrowed book" };

        if (!String.IsNullOrEmpty(bookUpdateDto.Title))
            bookToUpdate.Title = bookUpdateDto.Title;

        if (!String.IsNullOrEmpty(bookUpdateDto.Author))
            bookToUpdate.Author = bookUpdateDto.Author;

        if (Enum.IsDefined(bookUpdateDto.Genre))
            bookToUpdate.Genre = bookUpdateDto.Genre;

        if(bookUpdateDto.PublishYear > 0)
            bookToUpdate.PublishYear = bookUpdateDto.PublishYear;

        await _bookRepository.UpdateBook(bookToUpdate);

        return new ServiceResult<BookDto>()
        {
            Body = _mapper.Map<BookDto>(bookToUpdate),
            Status = 200
        };
    }

    public async Task<ServiceResult<BookDto>> RemoveBook(int id)
    {
        var bookToRemove = await _bookRepository.GetBookById(id);

        if (bookToRemove == null)
            return new ServiceResult<BookDto>() { Status = 404 };

        if (bookToRemove.IsBorrowed)
            return new ServiceResult<BookDto>() { Status = 500, Message = "Can't remove borrowed book" };

        await _bookRepository.RemoveBook(bookToRemove);

        return new ServiceResult<BookDto>()
        {
            Body = _mapper.Map<BookDto>(bookToRemove),
            Status = 200
        };
    }

    public async Task<ServiceResult<List<BookDto>>> GetRecommendedBooks(int userId)
    {
        var user = await _userRepository.GetUserById(userId);

        if (user is null)
            return new ServiceResult<List<BookDto>>() { Status = 404 };

        var borrowedBooks = await _borrowedBookRepository.GetRatedBorrowedBooksByUser(user.Id);

        if (borrowedBooks.Count == 0)
            return new ServiceResult<List<BookDto>>() { Status = 200, Body = new List<BookDto>() };

        var ratings = await _bookRatingRepository.GetAllBookRatingsByUser(user.Id);

        var allBooks = await _bookRepository.GetAllBooks();

        var filtered = allBooks.ExceptBy(borrowedBooks.Select(x => x.Book.Id), book => book.Id);

        filtered = filtered.Where(x=> ratings.Any(y=>y.Rating >=3 && (y.Book.Author == x.Author || y.Book.Genre == x.Genre)));

        filtered = filtered.Where(x => borrowedBooks.Any(y => y.Book.Author == x.Author || y.Book.Genre == x.Genre)).OrderByDescending(x=>x.Rating);

        return new ServiceResult<List<BookDto>>() { Status = 200, Body = _mapper.Map<List<BookDto>>(filtered) };
    }
}