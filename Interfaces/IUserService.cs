

using LibraryBackend.Dtos;

namespace Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> SignIn(UserSignInDto userSignInDto);
        public Task<UserDto> SignUp(UserSignUpDto userSignUpDto);
    }
}