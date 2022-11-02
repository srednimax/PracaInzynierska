using LibraryBackend.Dtos.Book;
using LibraryBackend.Dtos.User;
using LibraryDatabase.Models;

namespace LibraryBackend.Dtos.BorrowedBook;

public class BorrowedBookDto
{
    public int Id { get; set; }
    public BookDto? Book { get; set; }
    public UserDto? Employee { get; set; }
    public UserDto? Reader { get; set; }
    public Status Status { get; set; }
    public DateTime? BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsRenew { get; set; }
    public bool IsReturned { get; set; }
    public bool IsRated { get; set; }
}