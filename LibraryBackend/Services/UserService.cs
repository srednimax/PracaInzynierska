using LibraryBackend.Dtos;
using Services.Interfaces;

namespace Services
{
    public class UserService: IUserService
    {
        public Task<UserDto> SignIn(UserSignInDto userSignInDto)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> SignUp(UserSignUpDto userSignUpDto)
        {
            throw new NotImplementedException();
        }
    }
}