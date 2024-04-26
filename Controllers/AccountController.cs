using System.Security.Claims;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;
using ElectronicHealthProfile.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicHealthProfile.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly TokenService _tokenService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public AccountController(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager, TokenService tokeService,
        RoleManager<IdentityRole> roleManager,
        IHttpContextAccessor httpContextAccessor)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _tokenService = tokeService;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);

        if(user == null) return Unauthorized();

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        if(result.Succeeded) return await CreateUserObject(user);

        return Unauthorized();
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if(await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
        {
            ModelState.AddModelError("email", "Email taken");
            return ValidationProblem();
        }

        var user = new AppUser
        {
            Email = registerDto.Email,
            UserName = registerDto.Username
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if(result.Succeeded) return await CreateUserObject(user);

        return BadRequest("Problem registering user");
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
        var user = await _userManager.Users
            .FirstOrDefaultAsync(x => x.UserName == _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name));
        var userDto = await CreateUserObject(user);
        return await CreateUserObject(user);
    }

    private async Task<UserDto> CreateUserObject(AppUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        return new UserDto
        {
            Token = await _tokenService.CreateToken(user),
            Username = user.UserName,
            InstitutionId = user.InstitutionId,
            Roles = roles
        };
    }
}
