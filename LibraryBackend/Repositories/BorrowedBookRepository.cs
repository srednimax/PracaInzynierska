using LibraryBackend.Repositories.Interfaces;
using LibraryDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryBackend.Repositories;

public class BorrowedBookRepository: Repository<BorrowedBook>, IBorrowedBookRepository
{
    public BorrowedBookRepository(LibraryDatabaseContext context) : base(context) { }
    public async Task<List<BorrowedBook>> GetAllBorrowedBooks()
    {
        return await GetAll()
            .Include(x => x.Book)
            .Include(x => x.Employee)
            .Include(x => x.Reader)
            .ToListAsync();
    }

    public async Task<BorrowedBook?> GetBorrowedBookById(int id)
    {
        return await GetAll()
            .Include(x => x.Book)
            .Include(x => x.Employee)
            .Include(x => x.Reader)
            .FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<List<BorrowedBook>> GetBorrowedBooksByUser(int userId)
    {
        return await GetAll()
            .Include(x => x.Book)
            .Include(x => x.Employee)
            .Include(x => x.Reader)
            .Where(x=>x.Reader.Id==userId).ToListAsync();
    }

    public async Task<BorrowedBook> AddBorrowedBook(BorrowedBook borrowedBook)
    {
        return await AddAsync(borrowedBook);
    }

    public async Task<BorrowedBook> UpdateBorrowedBook(BorrowedBook borrowedBook)
    {
        return await UpdateAsync(borrowedBook);
    }
}