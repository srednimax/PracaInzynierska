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
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<UserDto>> SignUp(UserSignUpDto userSignUpDto)
        {

            var sameEmail = await _userRepository.GetUserByEmail(userSignUpDto.Email);
            if (sameEmail is not null)
            {
                // email exist in database
                return new ServiceResult<UserDto>() { Status = 1 };
            }

            var newUser = await _userRepository.AddUser( _mapper.Map<User>(userSignUpDto));

            if (newUser == null)
                return new ServiceResult<UserDto>() { Status = 400 };

            return new ServiceResult<UserDto>()
            {
                Body = _mapper.Map<UserDto>(newUser),
                Status = 200
            };
        }
    }
}