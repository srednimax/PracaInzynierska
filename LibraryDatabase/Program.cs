using LibraryDatabase.Models;

Console.WriteLine("Hello, World!");
var dbContext = new LibraryDatabaseContext();


/*var gen = new List<Genre>()
{
    new Genre()
    {
        Name = "Fikcja literacka"
    },
    new Genre()
    {
        Name = "Thriller"
    },
    new Genre()
    {
        Name = "Horror"
    },
    new Genre()
    {
        Name = "Historyczna"
    }, new Genre()
    {
        Name = "Romans"
    }, new Genre()
    {
        Name = "Western"
    },
    new Genre()
    {
        Name = "Fantastyka naukowa"
    },
    new Genre()
    {
        Name = "Fantasy"
    },
};
dbContext.Genres.AddRange(gen);
dbContext.SaveChanges();*/

/*var genres = dbContext.Genres.ToList();

var books = new List<Book>()
{
    new Book()
    {
        Title ="Title 1",
        Author = "Author 2",
        Genres = new List<Genre>(genres.GetRange(0,1)),
        PublishYear = 1999
    },
    new Book()
    {
        Title ="Title 2",
        Author = "Author 1",
        Genres = new List<Genre>(genres.GetRange(0,1)),
        PublishYear = 2001
    },
    new Book()
    {
        Title ="Title 3",
        Author = "Author 2",
        Genres = new List<Genre>(genres.GetRange(0,2)),
        PublishYear = 2005
    },
    new Book()
    {
        Title ="Title 4",
        Author = "Author 3",
        Genres = new List<Genre>(genres.GetRange(0,3)),
        PublishYear = 2008
    },
    new Book()
    {
        Title ="Title 5",
        Author = "Author 4",
        Genres = new List<Genre>(genres.GetRange(2,2)),
        PublishYear = 1998
    },
    new Book()
    {
        Title ="Title 6",
        Author = "Author 5",
        Genres = new List<Genre>(genres.GetRange(2,2)),
        PublishYear = 2003
    },
    new Book()
    {
        Title ="Title 7",
        Author = "Author 3",
        Genres = new List<Genre>(genres.GetRange(3,2)),
        PublishYear = 1998
    },new Book()
    {
        Title ="Title 8",
        Author = "Author 1",
        Genres = new List<Genre>(genres.GetRange(3,1)),
        PublishYear = 1990
    },
    new Book()
    {
        Title ="Title 9",
        Author = "Author 2",
        Genres = new List<Genre>(genres.GetRange(4,1)),
        PublishYear = 2004
    },
    new Book()
    {
        Title ="Title 10",
        Author = "Author 3",
        Genres = new List<Genre>(genres.GetRange(5,1)),
        PublishYear = 2013
    },
    new Book()
    {
        Title ="Title 11",
        Author = "Author 4",
        Genres = new List<Genre>(genres.GetRange(6,1)),
        PublishYear = 2015
    },
    new Book()
    {
        Title ="Title 12",
        Author = "Author 5",
        Genres = new List<Genre>(genres.GetRange(3,1)),
        PublishYear = 1999
    },
    new Book()
    {
        Title ="Title 13",
        Author = "Author 2",
        Genres = new List<Genre>(genres.GetRange(2,1)),
        PublishYear = 2007
    },
    new Book()
    {
        Title ="Title 14",
        Author = "Author 1",
        Genres = new List<Genre>(genres.GetRange(4,1)),
        PublishYear = 2004
    },
    new Book()
    {
        Title ="Title 15",
        Author = "Author 2",
        Genres = new List<Genre>(genres.GetRange(5,1)),
        PublishYear = 1992
    },
    new Book()
    {
        Title ="Title 16",
        Author = "Author 3",
        Genres = new List<Genre>(genres.GetRange(4,1)),
        PublishYear = 2010
    },
    new Book()
    {
        Title ="Title 17",
        Author = "Author 5",
        Genres = new List<Genre>(genres.GetRange(3,1)),
        PublishYear = 2008
    },
    new Book()
    {
        Title ="Title 18",
        Author = "Author 2",
        Genres = new List<Genre>(genres.GetRange(2,1)),
        PublishYear = 2001
    },
    new Book()
    {
        Title ="Title 19",
        Author = "Author 1",
        Genres = new List<Genre>(genres.GetRange(5,1)),
        PublishYear = 1999
    },
    new Book()
    {
        Title ="Title 20",
        Author = "Author 3",
        Genres = new List<Genre>(genres.GetRange(4,1)),
        PublishYear = 2016
    },
    new Book()
    {
        Title ="Title 21",
        Author = "Author 4",
        Genres = new List<Genre>(genres.GetRange(3,2)),
        PublishYear = 2015
    },
    new Book()
    {
        Title ="Title 22",
        Author = "Author 5",
        Genres = new List<Genre>(genres.GetRange(4,1)),
        PublishYear = 2004
    },
    new Book()
    {
        Title ="Title 23",
        Author = "Author 1",
        Genres = new List<Genre>(genres.GetRange(2,1)),
        PublishYear = 2005
    },
    new Book()
    {
        Title ="Title 24",
        Author = "Author 6",
        Genres = new List<Genre>(genres.GetRange(5,1)),
        PublishYear = 2015
    },
    new Book()
    {
        Title ="Title 25",
        Author = "Author 7",
        Genres = new List<Genre>(genres.GetRange(3,1)),
        PublishYear = 2006
    },
    new Book()
    {
        Title ="Title 26",
        Author = "Author 8",
        Genres = new List<Genre>(genres.GetRange(6,1)),
        PublishYear = 2012
    },
    new Book()
    {
        Title ="Title 27",
        Author = "Author 9",
        Genres = new List<Genre>(genres.GetRange(2,2)),
        PublishYear = 2012
    },
    new Book()
    {
        Title ="Title 28",
        Author = "Author 10",
        Genres = new List<Genre>(genres.GetRange(3,2)),
        PublishYear = 2013
    },
    new Book()
    {
        Title ="Title 29",
        Author = "Author 11",
        Genres = new List<Genre>(genres.GetRange(2,3)),
        PublishYear = 2013
    },
    new Book()
    {
        Title ="Title 30",
        Author = "Author 12",
        Genres = new List<Genre>(genres.GetRange(2,3)),
        PublishYear = 2007
    },
};

dbContext.AddRange(books);
dbContext.SaveChanges();*/