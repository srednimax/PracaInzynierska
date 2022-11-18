﻿namespace LibraryDatabase.Models;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Book> Books { get; set; }
    public List<BookGenre> BookGenres { get; set; }
}