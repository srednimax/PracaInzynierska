﻿using LibraryBackend.Repositories.Interfaces;
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
            .ThenInclude(x => x.Genres)
            .Include(x => x.Employee)
            .Include(x => x.Reader)
            .OrderBy(x=>x.Status)
            .ToListAsync();
    }

    public async Task<BorrowedBook?> GetBorrowedBookById(int id)
    {
        return await GetAll()
            .Include(x => x.Book)
            .ThenInclude(x => x.Genres)
            .Include(x => x.Employee)
            .Include(x => x.Reader)
            .FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<bool> CheckIfUserBookedBook(int bookId, int userId)
    {
        var borrowedBook= await GetAll()
            .Include(x => x.Book)
            .ThenInclude(x => x.Genres)
            .Include(x => x.Employee)
            .Include(x => x.Reader)
            .FirstOrDefaultAsync(x => x.Book.Id == bookId && x.Reader.Id == userId);

        return borrowedBook is not null;
    }

    public async Task<List<BorrowedBook>> GetBorrowedBooksByUser(int userId)
    {
        return await GetAll()
            .Include(x => x.Book)
            .ThenInclude(x => x.Genres)
            .Include(x => x.Employee)
            .Include(x => x.Reader)
            .Where(x=>x.Reader.Id==userId && x.Status != Status.Cancel)
            .OrderBy(x=>x.Status)
            .ToListAsync();
    }

    public async Task<BorrowedBook?> GetBorrowedBookByUser(int userId, int bookId)
    {
        return await GetAll()
            .Include(x => x.Book)
            .ThenInclude(x => x.Genres)
            .Include(x => x.Employee)
            .Include(x => x.Reader)
            .FirstOrDefaultAsync(x => x.Book.Id == bookId && x.Reader.Id==userId);
    }

    public async Task<BorrowedBook> AddBorrowedBook(BorrowedBook borrowedBook)
    {
        return await AddAsync(borrowedBook);
    }

    public async Task<BorrowedBook> UpdateBorrowedBook(BorrowedBook borrowedBook)
    {
        return await UpdateAsync(borrowedBook);
    }

    public async Task<bool> MoreThanThreeBooks(int userId)
    {
        var userBorrowedBooks = await GetAll().Include(x => x.Reader).CountAsync(x => x.IsReturned == false && x.Status !=Status.Cancel);

        return userBorrowedBooks >= 3;
    }

    public async Task<List<BorrowedBook>> GetRatedBorrowedBooksByUser(int userId)
    {
        return await GetAll()
            .Include(x => x.Book)
            .ThenInclude(x => x.Genres)
            .Include(x => x.Reader)
            .Where(x => x.Reader.Id == userId && x.IsRated == true)
            .ToListAsync();
    }
}