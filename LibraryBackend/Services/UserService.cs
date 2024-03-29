﻿using AutoMapper;
using LibraryBackend.Dtos.User;
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

        public async Task<ServiceResult<UserDto>> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var user = await _userRepository.GetUserById(userUpdateDto.Id);

            if (user is null)
                return new ServiceResult<UserDto>() { Status = 404 };

            var sameEmail = await _userRepository.GetUserByEmail(userUpdateDto.Email);
            if (sameEmail is not null && sameEmail.Id != user.Id)
            {
                return new ServiceResult<UserDto>() { Status = 500, Message = "Email exist in database" };
            }

            user.Email = userUpdateDto.Email;
            user.FirstName = userUpdateDto.FirstName;
            user.LastName = userUpdateDto.LastName;
            user.PhoneNumber = userUpdateDto.PhoneNumber;
            user.Gender = userUpdateDto.Gender;

            return new ServiceResult<UserDto>()
                { Body = _mapper.Map<UserDto>(await _userRepository.UpdateUser(user)), Status = 200 };

        }

        public async Task<ServiceResult<UserDto>> UpdatePassword(UserUpdatePasswordDto userUpdatePasswordDto)
        {
            var user = await _userRepository.GetUserById(userUpdatePasswordDto.Id);
            if (user is null)
                return new ServiceResult<UserDto>() { Status = 404 };

            if (!BCrypt.Net.BCrypt.Verify(userUpdatePasswordDto.OldPassword, user.Password))
            {
                return new ServiceResult<UserDto>() { Status = 500, Message = "Wrong old password" };
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(userUpdatePasswordDto.NewPassword);

            return new ServiceResult<UserDto>()
                { Status = 200, Body = _mapper.Map<UserDto>(await _userRepository.UpdateUser(user)) };


        }

        public async Task<ServiceResult<UserDto>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user is null)
                return new ServiceResult<UserDto>() {Status= 404 };

            return new ServiceResult<UserDto>() { Body = _mapper.Map<UserDto>(user), Status = 200 };
        }

        public async Task<ServiceResult<UserDto>> PayPenalty(int userId)
        {
            var user = await _userRepository.GetUserById(userId);

            if (user is null)
                return new ServiceResult<UserDto>() { Status = 404 };

            if (user.Penalty == 0)
                return new ServiceResult<UserDto>() { Status = 500, Message = "You do not need to pay" };

            user.Penalty = 0;

            await _userRepository.UpdateUser(user);

            return new ServiceResult<UserDto>() { Status = 200, Body = _mapper.Map<UserDto>(user) };
        }
    }
}