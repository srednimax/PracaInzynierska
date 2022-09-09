using AutoMapper;
using LibraryBackend.Dtos.User;
using LibraryDatabase.Models;

namespace LibraryBackend.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserSignUpDto>().ReverseMap();
        CreateMap<User, UserSignInDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}