using LibraryBackend.Dtos.Book;

namespace LibraryBackend.Dtos.RatingBook;

public class BookRatingUpdateDto
{
    public int Id { get; set; }
    public BookDto? Book { get; set; }
    public string? Comment { get; set; }
    public int Rating { get; set; }
}