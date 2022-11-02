namespace LibraryDatabase.Models;

public enum Status
{
    Booked,
    WaitingForBook,
    Preparing,
    Ready,
    Received,
    Returned
}

public class BorrowedBook
{
    public int Id { get; set; }
    public Book? Book { get; set; }
    public User? Employee { get; set; }
    public User? Reader { get; set; }
    public Status Status { get; set; }
    public DateTime? BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsRenew { get; set; }
    public bool IsReturned { get; set; }
    public bool IsRated { get; set; }

}