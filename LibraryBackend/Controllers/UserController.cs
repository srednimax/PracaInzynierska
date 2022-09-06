using System.Diagnostics;
using System.Linq.Expressions;
using LibraryBackend.Dtos;
using LibraryBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        var result = await _userService.SignIn(userSignInDto);
        return result.Status switch
        {
            1   => Problem("Wrong e-mail or password"),
            200 => result.Body,
        };
    }
    [HttpPost("SignUp")]
    public async Task<ActionResult<UserDto>> SignUp(UserSignUpDto userSignUpDto)        
    {
        var result = await _userService.SignUp(userSignUpDto);
        return result.Status switch
        {
            1   => Problem("User with the same e-mail exist in database"),
            200 => result.Body,
            400 => BadRequest(),
            404 => NotFound()
        };
    }
}