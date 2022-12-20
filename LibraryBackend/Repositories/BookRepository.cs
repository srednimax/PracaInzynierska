using LibraryBackend.Repositories.Interfaces;
using LibraryDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryBackend.Repositories;

public class BookRepository: Repository<Book>,IBookRepository
{
    public BookRepository(LibraryDatabaseContext context) : base(context) { }
    public async Task<Book?> GetBookById(int id)
    {
        return await GetAll()
            .Include(x=>x.Genres)
            .FirstOrDefaultAsync(x=>x.Id == id);
    }

    public async Task<List<Book>> GetAllBooks()
    {
        return await GetAll()
            .Include(x => x.Genres)
            .OrderBy(x=>x.IsBorrowed)
            .ToListAsync();
    }

    public async Task<Book> AddBook(Book book)
    {
        return await AddAsync(book);
    }

    public async Task<Book> UpdateBook(Book book)
    {
        return await UpdateAsync(book);
    }

    public async Task<Book> RemoveBook(Book book)
    {
        return await RemoveAsync(book);
    }
}