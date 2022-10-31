using LibraryBackend.Dtos.Book;

namespace LibraryBackend.Dtos.RatingBook;

public class BookRatingAddDto
{
    public BookDto? Book { get; set; }
    public string? Comment { get; set; }
    public int Rating { get; set; }
}