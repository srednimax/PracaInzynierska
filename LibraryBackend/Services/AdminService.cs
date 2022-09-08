using AutoMapper;
using LibraryBackend.Dtos;
using LibraryBackend.Repositories.Interfaces;
using LibraryBackend.Services.Interfaces;
using LibraryDatabase.Models;

namespace LibraryBackend.Services;

public class AdminService:IAdminService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AdminService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<ServiceResult<UserDto>> ChangeRoleToEmployee(int id)
    {
        var user = await _userRepository.GetUserById(id);

        if (user is null)
        {
            return new ServiceResult<UserDto>() { Status = 404 };
        }

        if (user.Role == Role.Admin)
        {
            return new ServiceResult<UserDto>() { Status = 500,Message = "Can't change Admin role"};
        }

        if (user.Role == Role.Employee)
        {
            return new ServiceResult<UserDto>() { Status = 500,Message = "Already an employee"};
        }

        user.Role = Role.Employee;

        await _userRepository.UpdateUser(user);

        return new ServiceResult<UserDto>() { Body = _mapper.Map<UserDto>(user), Status = 200 };
    }
    public async Task<ServiceResult<UserDto>> ChangeRoleToUser(int id)
    {
        var user = await _userRepository.GetUserById(id);

        if (user is null)
        {
            return new ServiceResult<UserDto>() { Status = 404 };
        }

        if (user.Role == Role.Admin)
        {
            return new ServiceResult<UserDto>() { Status = 500, Message = "Can't change Admin role" };
        }

        if (user.Role == Role.User)
        {
            return new ServiceResult<UserDto>() { Status = 500, Message = "Already an user" };
        }

        user.Role = Role.User;

        await _userRepository.UpdateUser(user);

        return new ServiceResult<UserDto>() { Body = _mapper.Map<UserDto>(user), Status = 200 };
    }

    public async Task<ServiceResult<UserDto>> Remove(int id)
    {
        var userToRemove = await _userRepository.GetUserById(id);
        if(userToRemove is null)
            return new ServiceResult<UserDto>() { Status = 404};

        if (userToRemove.Role == Role.Admin)
        {
            return new ServiceResult<UserDto>() { Status = 500, Message = "Can't remove Admin" };
        }

        await _userRepository.RemoveUser(userToRemove);

        return new ServiceResult<UserDto>() { Body = _mapper.Map<UserDto>(userToRemove), Status = 200 };

    }
}