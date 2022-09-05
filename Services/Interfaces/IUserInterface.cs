using LibraryBackend.Dtos;

namespace Services.Interfaces;

public interface IUserService
{
    public Task<UserDto> SignIn(UserSignInDto userSignInDto);
    public Task<UserDto> SignUp(UserSignUpDto userSignUpDto);
}