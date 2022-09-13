using LibraryDatabase.Models;

namespace LibraryBackend.Repositories.Interfaces;

public interface IBookRepository
{
    public Task<Book?> GetBookById(int id);
    public Task<List<Book>> GetAllBooks();
    public Task<Book> AddBook(Book book);
    public Task<Book> UpdateBook(Book book);
    public Task<Book> RemoveBook(Book book);
}