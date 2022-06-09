namespace Models;

[Flags]
public enum Genre
{
    LiteraryFiction,
    Mystery,
    Thriller,
    Horror,
    Historical,
    Romance,
    Western,
    SpeculativeFiction,
    ScienceFiction,
    Fantasy,
    Dystopian,
    MagicalRealism,
    RealistLiterature
}

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public Genre Genre { get; set; }
    public DateTime PublishDate { get; set; }
}