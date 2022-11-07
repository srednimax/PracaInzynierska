using LibraryBackend.Dtos.RatingBook;

namespace LibraryBackend.Services.Interfaces;

public interface IBookRatingService
{
    public Task<ServiceResult<List<BookRatingDto>>> GetAllBooksRating();
    public Task<ServiceResult<List<BookRatingDto>>> GetAllBooksRatingByUser(int userId);
    public Task<ServiceResult<List<BookRatingDto>>> GetAllBooksRatingByBook(int bookId);
    public Task<ServiceResult<BookRatingDto>> GetBookRatingById(int id);
    public Task<ServiceResult<BookRatingDto>> AddBookRating(BookRatingAddDto bookRatingAddDto);
    public Task<ServiceResult<BookRatingDto>> UpdateBookRating(BookRatingUpdateDto bookRatingUpdateDto);
    public Task<ServiceResult<BookRatingDto>> RemoveBookRating(BookRatingRemoveDto bookRatingRemoveDto);
}