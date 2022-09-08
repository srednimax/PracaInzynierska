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

        [HttpPut]
        public async Task<ActionResult<UserDto>> ChangeRoleToEmployee(int id)
        {
            var result = await _adminService.ChangeRoleToEmployee(id);

            return result.Status switch
            {
                1 => Problem(result.Message),
                2 => Problem(result.Message),
                200 => result.Body
            };
        }
    }
}
