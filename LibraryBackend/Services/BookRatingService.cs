using AutoMapper;
using LibraryBackend.Dtos.RatingBook;
using LibraryBackend.Repositories.Interfaces;
using LibraryBackend.Services.Interfaces;

namespace LibraryBackend.Services;

public class BookRatingService :IBookRatingService
{
    private readonly IBookRatingRepository _bookRatingRepository;
    private readonly IBorrowedBookRepository _borrowedBookRepository;
    private readonly IMapper _mapper;

    public BookRatingService(IBookRatingRepository bookRatingRepository, IBorrowedBookRepository borrowedBookRepository, IMapper mapper)
    {
        _bookRatingRepository = bookRatingRepository;
        _borrowedBookRepository = borrowedBookRepository;
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

    public async Task<ServiceResult<BookRatingDto>> AddBookRating(BookRatingAddDto bookRatingAddDto)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResult<BookRatingDto>> UpdateBookRating(BookRatingUpdateDto bookRatingUpdateDto)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResult<BookRatingDto>> RemoveBookRating(int id)
    {
        throw new NotImplementedException();
    }
}