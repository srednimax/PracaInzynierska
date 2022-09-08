using System.Diagnostics;
using System.Linq.Expressions;
using System.Security.Claims;
using AutoMapper;
using LibraryBackend.Authentication;
using LibraryBackend.Dtos;
using LibraryBackend.Services.Interfaces;
using LibraryDatabase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuth _auth;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IAuth auth, IMapper mapper)
    {
        _userService = userService;
        _auth = auth;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpPost("SignIn")]
    public async Task<ActionResult<UserDto>> SignIn(UserSignInDto userSignInDto)
    {
        var result = await _userService.SignIn(userSignInDto);
        switch (result.Status)
        {
            case 200:
                var token = _auth.Authentication(_mapper.Map<User>(result.Body));
                HttpContext.Response.Headers.Add("jwt",token);
                return result.Body;
            case 500:
                return Problem(result.Message);
            default:
                return BadRequest();
        }
    }
    [AllowAnonymous]
    [HttpPost("SignUp")]
    public async Task<ActionResult<UserDto>> SignUp(UserSignUpDto userSignUpDto)        
    {
        var result = await _userService.SignUp(userSignUpDto);
        return result.Status switch
        {
            200 => result.Body,
            400 => BadRequest(),
            404 => NotFound(),
            500 => Problem(result.Message)
        };
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<UserDto>> GetLoggedUser()
    {
        var userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);

        var result = await _userService.GetUserById(userId);

        return result.Status switch
        {
            200 => result.Body,
            404 => NotFound(),
            500 => Problem(result.Message)
        };
    }
}