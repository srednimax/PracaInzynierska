using LibraryBackend.Dtos;

namespace LibraryBackend.Services.Interfaces;

public interface IAdminService
{
    public Task<ServiceResult<UserDto>> ChangeRoleToEmployee(int id);
}