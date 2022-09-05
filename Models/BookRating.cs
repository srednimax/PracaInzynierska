namespace Models;

public class BookRating
{
    public int Id { get; set; }
    public Book? Book { get; set; }
    public string? Comment { get; set; }
    public int Rating { get; set; }
}