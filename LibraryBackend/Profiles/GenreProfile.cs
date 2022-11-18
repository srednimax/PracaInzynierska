using AutoMapper;
using LibraryBackend.Dtos.Genre;
using LibraryDatabase.Models;

namespace LibraryBackend.Profiles;

public class GenreProfile : Profile
{
    public GenreProfile()
    {
        CreateMap<Genre,GenreDto>().ReverseMap();
        CreateMap<Genre,GenreAddDto>().ReverseMap();
        CreateMap<Genre,GenreUpdateDto>().ReverseMap();
    }
}