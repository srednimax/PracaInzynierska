using AutoMapper;
using LibraryBackend.Dtos.RatingBook;
using LibraryDatabase.Models;

namespace LibraryBackend.Profiles;

public class BookRatingProfile:Profile
{
    public BookRatingProfile()
    {
        CreateMap<BookRating, BookRatingDto>().ReverseMap();
        CreateMap<BookRating, BookRatingAddDto>().ReverseMap();
        CreateMap<BookRating, BookRatingUpdateDto>().ReverseMap();
    }
}