using LibraryBackend.Dtos.User;

namespace LibraryBackend.Services.Interfaces;

public interface IUserService
{
    public Task<ServiceResult<UserDto>> SignIn(UserSignInDto userSignInDto);
    public Task<ServiceResult<UserDto>> SignUp(UserSignUpDto userSignUpDto);
    public Task<ServiceResult<UserDto>> GetUserById(int id);
}