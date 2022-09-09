using LibraryBackend.Dtos.User;

namespace LibraryBackend.Services.Interfaces;

public interface IAdminService
{
    public Task<ServiceResult<UserDto>> ChangeRoleToEmployee(int id);
    public Task<ServiceResult<UserDto>> ChangeRoleToUser(int id);
    public Task<ServiceResult<UserDto>> Remove(int id);
}