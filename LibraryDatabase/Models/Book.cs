namespace LibraryDatabase.Models;


public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public List<Genre> Genres { get; set; }
    public List<BookGenre> BookGenres { get; set; }
    public int PublishYear { get; set; }
    public bool IsBorrowed { get; set; }
    public float Rating { get; set; }
}