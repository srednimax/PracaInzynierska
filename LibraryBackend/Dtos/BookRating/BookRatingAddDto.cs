using System.ComponentModel.DataAnnotations;
using LibraryBackend.Dtos.Book;
using LibraryBackend.Dtos.User;

namespace LibraryBackend.Dtos.RatingBook;

public class BookRatingAddDto
{
    public int UserId { get; set; }

    [Required]
    public int BookId { get; set; }

    [Required]
    [MaxLength(300)]
    public string? Comment { get; set; }

    [Required]
    [Range(typeof(int),"1","5")]
    public int Rating { get; set; }
}