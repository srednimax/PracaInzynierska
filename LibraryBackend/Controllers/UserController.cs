using LibraryBackend.Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace LibraryBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("SignIn")]
    public async Task<ActionResult<UserDto>> SignIn(UserSignInDto userSignInDto)
    {
        return await _userService.SignIn(userSignInDto);
    }
    [HttpPost("SignUp")]
    public async Task<ActionResult<UserDto>> SignUp(UserSignUpDto userSignUpDto)        
    {
        return await _userService.SignUp(userSignUpDto);
    }
}