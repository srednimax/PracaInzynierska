using System.ComponentModel.DataAnnotations;

namespace LibraryBackend.Dtos.BorrowedBook;

public class BorrowedBookAddDto
{
    public int UserId { get; set; }

    [Required]
    public int BookId { get; set; }
}