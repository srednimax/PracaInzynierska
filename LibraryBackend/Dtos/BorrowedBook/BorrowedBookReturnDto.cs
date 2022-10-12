using System.ComponentModel.DataAnnotations;

namespace LibraryBackend.Dtos.BorrowedBook;

public class BorrowedBookReturnDto
{
    [Required]
    public int BorrowedBookId { get; set; }
    public int UserId { get; set; }
}