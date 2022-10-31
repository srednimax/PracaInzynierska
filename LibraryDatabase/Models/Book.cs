namespace LibraryDatabase.Models;

public enum Genre
{
    LiteraryFiction,
    Thriller,
    Horror,
    Historical,
    Romance,
    Western,
    ScienceFiction,
    Fantasy,
}

public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public Genre Genre { get; set; }
    public int PublishYear { get; set; }
    public bool IsBorrowed { get; set; }
    public float Rating { get; set; }
}