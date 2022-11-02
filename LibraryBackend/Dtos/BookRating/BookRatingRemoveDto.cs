using System.ComponentModel.DataAnnotations;

namespace LibraryBackend.Dtos.RatingBook;

public class BookRatingRemoveDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int BorrowedBookId { get; set; }

    public int UserId { get; set; }
}