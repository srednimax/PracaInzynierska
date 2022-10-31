using LibraryBackend.Dtos.Book;
using LibraryBackend.Dtos.User;

namespace LibraryBackend.Dtos.RatingBook;

public class BookRatingUpdateDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public string? Comment { get; set; }
    public int Rating { get; set; }
}