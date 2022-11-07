using System.Globalization;
using AutoMapper;
using LibraryBackend.Dtos.RatingBook;
using LibraryBackend.Repositories.Interfaces;
using LibraryBackend.Services.Interfaces;
using LibraryDatabase.Models;

namespace LibraryBackend.Services;

public class BookRatingService : IBookRatingService
{
    private readonly IBookRatingRepository _bookRatingRepository;
    private readonly IBorrowedBookRepository _borrowedBookRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public BookRatingService(IBookRatingRepository bookRatingRepository, IBorrowedBookRepository borrowedBookRepository, IBookRepository bookRepository, IUserRepository userRepository, IMapper mapper)
    {
        _bookRatingRepository = bookRatingRepository;
        _borrowedBookRepository = borrowedBookRepository;
        _bookRepository = bookRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResult<List<BookRatingDto>>> GetAllBooksRating()
    {
        return new ServiceResult<List<BookRatingDto>>()
        {
            Body = _mapper.Map<List<BookRatingDto>>(await _bookRatingRepository.GetAllBooks()),
            Status = 200
        };
    }

    public async Task<ServiceResult<List<BookRatingDto>>> GetAllBooksRatingByUser(int userId)
    {
        var user = await _userRepository.GetUserById(userId);

        if (user is null)
            return new ServiceResult<List<BookRatingDto>>() { Status = 404 };

        var bookRatings = await _bookRatingRepository.GetAllBookRatingsByUser(user.Id);

        return new ServiceResult<List<BookRatingDto>>() { Status = 200,Body = _mapper.Map<List<BookRatingDto>>(bookRatings)};
    }

    public async Task<ServiceResult<List<BookRatingDto>>> GetAllBooksRatingByBook(int bookId)
    {
        var book = await _bookRepository.GetBookById(bookId);

        if (book is null)
            return new ServiceResult<List<BookRatingDto>>() { Status = 404 };

        var ratings = await _bookRatingRepository.GetAllBookRatingsByBook(bookId);

        return new ServiceResult<List<BookRatingDto>>()
            { Status = 200, Body = _mapper.Map<List<BookRatingDto>>(ratings) };
    }

    public async Task<ServiceResult<BookRatingDto>> GetBookRatingById(int id)
    {
        var bookRating = await _bookRatingRepository.GetBookRatingById(id);

        if (bookRating is null)
            return new ServiceResult<BookRatingDto>() { Status = 404 };

        return new ServiceResult<BookRatingDto>() { Body =_mapper.Map<BookRatingDto>(bookRating) ,Status = 200 };
    }

    public async Task<ServiceResult<BookRatingDto>> AddBookRating(BookRatingAddDto bookRatingAddDto)
    {
        var user = await _userRepository.GetUserById(bookRatingAddDto.UserId);

        if (user is null)
            return new ServiceResult<BookRatingDto>() { Status = 404 };

        var book = await _bookRepository.GetBookById(bookRatingAddDto.BookId);

        if (book is null)
            return new ServiceResult<BookRatingDto>() { Status = 404 };

        var borrowedBook = await _borrowedBookRepository.GetBorrowedBookByUser(bookRatingAddDto.UserId, bookRatingAddDto.BookId);

        if (borrowedBook is null)
            return new ServiceResult<BookRatingDto>() { Status = 404 };

        if (borrowedBook.Status != Status.Returned)
            return new ServiceResult<BookRatingDto>() { Status = 500, Message = "You must read it first." };

        if(borrowedBook.IsRated == true)
            return new ServiceResult<BookRatingDto>() { Status = 500, Message = "You rated it before." };

        var bookRating = new BookRating()
        {
            Book = book,
            Comment = bookRatingAddDto.Comment,
            Rating = bookRatingAddDto.Rating,
            User = user
        };
        var bookRatingDto = _mapper.Map<BookRatingDto>(await _bookRatingRepository.AddBookRating(bookRating));

        book.Rating = await _bookRatingRepository.CalculateRating(book.Id);
        borrowedBook.IsRated = true;

        await _bookRepository.UpdateBook(book);
        await _borrowedBookRepository.UpdateBorrowedBook(borrowedBook);

        return new ServiceResult<BookRatingDto>()
        { Status = 200, Body = bookRatingDto };


    }

    public async Task<ServiceResult<BookRatingDto>> UpdateBookRating(BookRatingUpdateDto bookRatingUpdateDto)
    {
        var user = await _userRepository.GetUserById(bookRatingUpdateDto.UserId);

        if (user is null)
            return new ServiceResult<BookRatingDto>() { Status = 404 };

        var book = await _bookRepository.GetBookById(bookRatingUpdateDto.BookId);

        if (book is null)
            return new ServiceResult<BookRatingDto>() { Status = 404 };

        var bookRating = await _bookRatingRepository.GetBookRatingById(bookRatingUpdateDto.Id);

        if (bookRating is null)
            return new ServiceResult<BookRatingDto>() { Status = 404 };


        if (bookRating.User.Id != user.Id)
            return new ServiceResult<BookRatingDto>() { Status = 500, Message = "This rating do not belong to you." };


        if (!String.IsNullOrEmpty(bookRatingUpdateDto.Comment))
        {
            bookRating.Comment = bookRatingUpdateDto.Comment;
        }

        if (bookRatingUpdateDto.Rating != bookRating.Rating)
        {
            bookRating.Rating = bookRatingUpdateDto.Rating;
        }


        var bookRatingDto = _mapper.Map<BookRatingDto>(await _bookRatingRepository.UpdateBookRating(bookRating));

        book.Rating = await _bookRatingRepository.CalculateRating(book.Id);

        await _bookRepository.UpdateBook(book);

        return new ServiceResult<BookRatingDto>()
        { Status = 200, Body = bookRatingDto };
    }

    public async Task<ServiceResult<BookRatingDto>> RemoveBookRating(BookRatingRemoveDto bookRatingRemoveDto)
    {
        var bookRating = await _bookRatingRepository.GetBookRatingById(bookRatingRemoveDto.Id);

        if (bookRating is null)
            return new ServiceResult<BookRatingDto>() { Status = 404 };

        var user = await _userRepository.GetUserById(bookRatingRemoveDto.UserId);

        if (user is null)
            return new ServiceResult<BookRatingDto>() { Status = 404 };

        if (bookRating.User.Id != user.Id)
            return new ServiceResult<BookRatingDto>() { Status = 500, Message = "This rating do not belong to you." };

        var book = await _bookRepository.GetBookById(bookRating.Book.Id);

        if (book is null)
            return new ServiceResult<BookRatingDto>() { Status = 404 };

        var borrowedBook = await _borrowedBookRepository.GetBorrowedBookById(bookRatingRemoveDto.BorrowedBookId);

        if (borrowedBook is null)
            return new ServiceResult<BookRatingDto>() { Status = 404 };


        var bookRatingDto = _mapper.Map<BookRatingDto>(await _bookRatingRepository.RemoveBookRating(bookRating));

        book.Rating = await _bookRatingRepository.CalculateRating(book.Id);

        borrowedBook.IsRated = false;

        await _bookRepository.UpdateBook(book);
        await _borrowedBookRepository.UpdateBorrowedBook(borrowedBook);

        return new ServiceResult<BookRatingDto>() { Status = 200, Body = bookRatingDto };

    }
}