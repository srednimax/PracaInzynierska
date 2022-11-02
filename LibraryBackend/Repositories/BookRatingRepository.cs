using LibraryBackend.Repositories.Interfaces;
using LibraryDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryBackend.Repositories;

public class BookRatingRepository : Repository<BookRating>, IBookRatingRepository
{
    public BookRatingRepository(LibraryDatabaseContext context) : base(context) { }
    public async Task<BookRating?> GetBookRatingById(int id)
    {
        return await GetAll()
            .Include(x => x.Book)
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<BookRating>> GetAllBooks()
    {
        return await GetAll()
            .Include(x => x.Book)
            .Include(x => x.User)
            .ToListAsync();
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

    public async Task<float> CalculateRating(int bookId)
    {
        var ratings = await GetAll()
            .Include(x => x.Book)
            .Where(x => x.Book.Id == bookId)
            .ToListAsync();

        if(ratings.Count == 0)
            return 0f;

        var rating = ratings.Average(x => x.Rating);
            

        return (float)Math.Round(rating, 0);
    }

}