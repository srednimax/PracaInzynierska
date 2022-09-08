using System.Diagnostics;
using System.Linq.Expressions;
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
            case 1:
                return Problem("Wrong e-mail or password");
            case 200:
                var token = _auth.Authentication(_mapper.Map<User>(result.Body));
                HttpContext.Response.Headers.Add("jwt",token);
                return result.Body;
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
            1   => Problem("User with the same e-mail exist in database"),
            200 => result.Body,
            400 => BadRequest(),
            404 => NotFound()
        };
    }
}