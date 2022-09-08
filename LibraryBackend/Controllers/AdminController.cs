using LibraryBackend.Dtos;
using LibraryBackend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBackend.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles="Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPut("ToEmployee")]
        public async Task<ActionResult<UserDto>> ChangeRoleToEmployee(int id)
        {
            var result = await _adminService.ChangeRoleToEmployee(id);

            return result.Status switch
            {
                200 => result.Body,
                500 => Problem(result.Message)
            };
        }
        [HttpPut("ToUser")]
        public async Task<ActionResult<UserDto>> ChangeRoleToUser(int id)
        {
            var result = await _adminService.ChangeRoleToUser(id);

            return result.Status switch
            {
                200 => result.Body,
                500 => Problem(result.Message)
            };
        }
        [HttpDelete]
        public async Task<ActionResult<UserDto>> RemoveUser(int id)
        {
            var result = await _adminService.Remove(id);

            return result.Status switch
            {
                200 => result.Body,
                404 => NotFound(),
                500 => Problem(result.Message)
            };
        }

    }
}
