using AutoMapper;
using LibraryBackend.Dtos;
using LibraryDatabase.Models;

namespace LibraryBackend.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserSignUpDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}