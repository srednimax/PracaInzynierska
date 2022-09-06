using LibraryBackend.Repositories.Interfaces;
using LibraryDatabase.Models;

namespace LibraryBackend.Repositories;

public class BookRatingRepository:Repository<BookRating>,IBookRatingRepository
{
    public BookRatingRepository(LibraryDatabaseContext context) : base(context) { }
}