using LibraryBackend.Dtos.Book;
using LibraryBackend.Dtos.User;

namespace LibraryBackend.Dtos.RatingBook;

public class BookRatingDto
{
    public int Id { get; set; }
    public BookDto? Book { get; set; }
    public UserDto? User { get; set; }
    public string? Comment { get; set; }
    public int Rating { get; set; }
}