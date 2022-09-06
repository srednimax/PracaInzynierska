using LibraryBackend.Repositories.Interfaces;
using LibraryDatabase.Models;

namespace LibraryBackend.Repositories;

public class BorrowedBookRepository: Repository<BorrowedBookRepository>, IBorrowedBookRepository
{
    public BorrowedBookRepository(LibraryDatabaseContext context) : base(context) { }
}