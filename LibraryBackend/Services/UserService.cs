using AutoMapper;
using LibraryBackend.Dtos;
using LibraryBackend.Repositories.Interfaces;
using LibraryBackend.Services.Interfaces;
using LibraryDatabase.Models;

namespace LibraryBackend.Services
{
    public class UserService: IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<ServiceResult<UserDto>> SignIn(UserSignInDto userSignInDto)
        {
            var userForVerifyPassword = await _userRepository.GetUserByEmail(userSignInDto.Email);

            if (userForVerifyPassword is not null &&
                BCrypt.Net.BCrypt.Verify(userSignInDto.Password, userForVerifyPassword.Password))
            {
                userSignInDto.Password = userForVerifyPassword.Password;
            }

            var user = await _userRepository.SignIn(_mapper.Map<User>(userSignInDto));
            if (user is null)
            {
                return new ServiceResult<UserDto>() { Status = 500,Message = "Wrong email or password" };
            }

            return new ServiceResult<UserDto>() { Body = _mapper.Map<UserDto>(user), Status = 200 };
        }

        public async Task<ServiceResult<UserDto>> SignUp(UserSignUpDto userSignUpDto)
        {

            var sameEmail = await _userRepository.GetUserByEmail(userSignUpDto.Email);
            if (sameEmail is not null)
            {
                return new ServiceResult<UserDto>() { Status = 500,Message = "Email exist in database"};
            }

            // hashing password
            userSignUpDto.Password = BCrypt.Net.BCrypt.HashPassword(userSignUpDto.Password);

            var newUser = await _userRepository.AddUser( _mapper.Map<User>(userSignUpDto));

            if (newUser == null)
                return new ServiceResult<UserDto>() { Status = 400 };

            return new ServiceResult<UserDto>()
            {
                Body = _mapper.Map<UserDto>(newUser),
                Status = 200
            };
        }

        public async Task<ServiceResult<UserDto>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
                return new ServiceResult<UserDto>() {Status= 404 };

            return new ServiceResult<UserDto>() { Body = _mapper.Map<UserDto>(user), Status = 200 };
        }
    }
}