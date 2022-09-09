using AutoMapper;
using LibraryBackend.Dtos.Book;
using LibraryDatabase.Models;

namespace LibraryBackend.Profiles;

public class BookProfile:Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<Book, BookAddDto>().ReverseMap();
        CreateMap<Book, BookUpdateDto>().ReverseMap();
    }
}