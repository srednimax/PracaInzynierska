using System.Text;
using LibraryDatabase.Models;
using Newtonsoft.Json;

namespace LibraryBackend.Test;

public class Utilities
{
    public static void InitializeDbForTests(LibraryDatabaseContext db)
    {
        db.Users.AddRange(GetUsers());
        db.SaveChanges();
        db.Genres.AddRange(GetGenres());
        db.SaveChanges();
        db.Books.AddRange(GetBooks(db));
        db.SaveChanges();
    }

    public static List<User> GetUsers()
    {
        return new List<User>
        {
            new User()
            {
                Email = "admin@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("123$Qwer"),
                FirstName = "Admin",LastName = "Nowak",
                PhoneNumber = "123456789",
                Gender = Gender.Male,
                Birth = DateTime.Now.AddYears(-20),
                Role = Role.Admin
            },
            new User()
            {
                Email = "emp@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("123$Qwer"),
                FirstName = "Emp",LastName = "Kowal",
                PhoneNumber = "124456789",
                Gender = Gender.Male,
                Birth = DateTime.Now.AddYears(-22),
                Role = Role.Employee
            },
            new User()
            {
                Email = "user@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("123$Qwer"),
                FirstName = "Maciek",LastName = "Przyt",
                PhoneNumber = "123455789",
                Gender = Gender.Male,
                Birth = DateTime.Now.AddYears(-25),
                Role = Role.User
            }
        };
    }

    public static List<Genre> GetGenres()
    {
        return new List<Genre>()
        {
            new Genre() { Name = "test" },
            new Genre() { Name = "test2" },
            new Genre() { Name = "test3" },
            new Genre() { Name = "test4" }
        };
    }

    public static List<Book> GetBooks(LibraryDatabaseContext db)
    {
        return new List<Book>()
        {
            new Book()
            {
                Author = "Author 1",
                Title = "Title 1",
                Genres = db.Genres.ToList(),
                PublishYear = 1999
            },
            new Book()
            {
                Author = "Author 2",
                Title = "Title 2",
                Genres = db.Genres.ToList(),
                PublishYear = 2001
            },
            new Book()
            {
                Author = "Author 3",
                Title = "Title 3",
                Genres = db.Genres.ToList(),
                PublishYear = 2004
            },
        };
    }
    public static StringContent Serialize<T>(T dto)
    {
        return new StringContent(JsonConvert.SerializeObject(dto), UnicodeEncoding.UTF8, "application/json");
    }

}