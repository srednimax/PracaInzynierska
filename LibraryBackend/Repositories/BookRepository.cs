using LibraryBackend.Repositories.Interfaces;
using LibraryDatabase.Models;

namespace LibraryBackend.Repositories;

public class BookRepository: Repository<BookRepository>,IBookRepository
{
    public BookRepository(LibraryDatabaseContext context) : base(context) { }
}