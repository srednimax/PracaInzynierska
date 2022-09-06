using LibraryBackend.Dtos;
using LibraryBackend.Services.Interfaces;

namespace LibraryBackend.Services
{
    public class UserService: IUserService
    {
        public async Task<ServiceResult<UserDto>> SignIn(UserSignInDto userSignInDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<UserDto>> SignUp(UserSignUpDto userSignUpDto)
        {
            throw new NotImplementedException();
        }
    }
}