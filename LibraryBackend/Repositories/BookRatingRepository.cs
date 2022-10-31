using LibraryBackend.Repositories.Interfaces;
using LibraryDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryBackend.Repositories;

public class BookRatingRepository:Repository<BookRating>,IBookRatingRepository
{
    public BookRatingRepository(LibraryDatabaseContext context) : base(context) { }
    public async Task<BookRating?> GetBookRatingById(int id)
    {
        return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<BookRating>> GetAllBooks()
    {
        return await GetAll().ToListAsync();
    }

    public async Task<BookRating> AddBookRating(BookRating bookRating)
    {
        return await AddAsync(bookRating);
    }

    public async Task<BookRating> UpdateBookRating(BookRating bookRating)
    {
        return await UpdateAsync(bookRating);
    }

    public async Task<BookRating> RemoveBookRating(BookRating bookRating)
    {
        return await RemoveAsync(bookRating);
    }
}