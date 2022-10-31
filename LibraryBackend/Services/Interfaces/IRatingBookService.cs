using LibraryBackend.Dtos.RatingBook;

namespace LibraryBackend.Services.Interfaces;

public interface IRatingBookService
{
    public Task<ServiceResult<List<RatingBookDto>>> GetAllBooks();
    public Task<ServiceResult<RatingBookDto>> AddBook(RatingBookAddDto ratingBookAddDto);
    public Task<ServiceResult<RatingBookDto>> UpdateBook(RatingBookUpdateDto ratingBookUpdateDto);
    public Task<ServiceResult<RatingBookDto>> RemoveBook(int id);
}