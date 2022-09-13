using AutoMapper;
using LibraryBackend.Dtos.BorrowedBook;
using LibraryDatabase.Models;

namespace LibraryBackend.Profiles;

public class BorrowedBookProfile:Profile
{
    public BorrowedBookProfile()
    {
        CreateMap<BorrowedBook, BorrowedBookDto>().ReverseMap();
    }
}