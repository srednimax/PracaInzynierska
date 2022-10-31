using System.ComponentModel.DataAnnotations;
using LibraryBackend.Dtos.Book;
using LibraryBackend.Dtos.User;

namespace LibraryBackend.Dtos.RatingBook;

public class BookRatingUpdateDto
{
    [Required]
    public int Id { get; set; }
    public int UserId { get; set; }

    [Required]
    public int BookId { get; set; }
    public string? Comment { get; set; }
    public int Rating { get; set; }
}